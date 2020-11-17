import { Component, EventEmitter, OnInit, Output, ViewChild } from '@angular/core';
import { FormBuilder, FormGroup, FormsModule, Validators } from '@angular/forms';
import { FormGroupDirective } from '@angular/forms';
import { FormStatus } from 'src/app/core/enums/form-status.enum';
import { ResponseStatus } from 'src/app/core/enums/response-status.enum';
import { ResponseModel } from 'src/app/core/models/response.model';
import { NotificationService } from 'src/app/shared/services/toastr.service';
import { JobCategoryService } from '../../config-system/job-category/job-category.service';
import { SkillService } from '../../config-system/skill/skill.service';
import { Recruitment } from '../recruitment.model';
import { RecruitmentService } from '../recruitment.service';

@Component({
  selector: 'app-form',
  templateUrl: './form.component.html',
  styleUrls: ['./form.component.css']
})
export class FormComponent implements OnInit {

  @ViewChild(FormGroupDirective) formDirective: FormGroupDirective;
  @Output() isShow = new EventEmitter<boolean>();

  public recruitmentForm: FormGroup;
  public action:FormStatus;
  public listSkills : any[];
  public listCategorys : any[];
  public recruitment : Recruitment;


  constructor(
    private fb : FormBuilder,
    private recService : RecruitmentService,
    private notify : NotificationService,
    private skillService: SkillService,
    private jobcategoryService: JobCategoryService
  ) { }

  ngOnInit(): void {
    this.recruitmentForm = this.fb.group({
      id:[0,Validators.required],
      title:['',Validators.required],
      description:['',Validators.required],
      skill:['',Validators.required],
      categoryId:['',Validators.required],
      offerfrom:['',Validators.required],
      offerto:['',Validators.required],
      requestJob:['',Validators.required],
      benefit:['',Validators.required],
      endow:['',Validators.required],
      timeEnd:['',Validators.required],
      timeStart:['',Validators.required],
      quatity:['',Validators.required],
    });
    this.action = FormStatus.Unknow;
    this.dropdownSkill();
    this.dropdownCategory();
  }

  showForm(){
    if(this.action == FormStatus.Unknow)
      return false;
    return true;
  }
  
  saveFormRecruit(){
    if(this.recruitmentForm.invalid){
      this.notify.showWarning("Nhập đầy đủ thông tin!","Thông báo");
      return;
    }
    const formValues = this.recruitmentForm.getRawValue();
    const formData = this.ToFormData(formValues);
    if(this.action == FormStatus.Insert){
      this.recService.insert(formData).subscribe((res:ResponseModel)=>{
        if(res.status == ResponseStatus.success){
          this.isShow.emit(true);
          this.notify.showSuccess("Đã thêm thành công","Thông báo");
          this.initialForm();
        }
        else{
          this.notify.showWarning("Thêm thất bại","Thông báo");
        }
      })
    }
    else if(this.action == FormStatus.Update){
      this.recService.update(formData).subscribe((res:ResponseModel)=>{
        if(res.status == ResponseStatus.success){
          this.isShow.emit(true);
          this.notify.showSuccess("Cập nhật thành công","Thông báo");
          this.action == FormStatus.Insert;
          this.initialForm();
        }
        else{
          this.notify.showWarning("Cập nhật thất bại","Thông báo");
        }        
      })
    }
  }

  OpenFormInsert(){
    this.action = FormStatus.Insert;
    this.isShow.emit(false);
  }
  OpenFormUpdate(id:number){
    this.action = FormStatus.Update;
    this.isShow.emit(false);
    this.getItem(id);
  }

  ToFormData(formValue: any) {
    const formData = new FormData();
    for (const key of Object.keys(formValue)) {
      let value = formValue[key];
      if(key === "timeStart" || key ==="timeEnd"){
        const month = value.getMonth()+1;
        const day = value.getDate();
        const year = value.getFullYear();
        value = `${month}-${day}-${year}`;
        console.log(value);
      }
      else if(key==="skill"){
        let tmp = "";
        value.forEach(element => {
          tmp = tmp + element + ",";
        });
        value = tmp;
      }
      formData.append(key, value);
    }
    return formData;
  }
  onBack(){
    this.action = FormStatus.Unknow;
    this.isShow.emit(true);
  }

  dropdownSkill(){
    return this.skillService.dropdown().subscribe((res:ResponseModel)=>{
      if(res.status == ResponseStatus.success){
        this.listSkills = res.result;
      }
    })
  }

  dropdownCategory(){
    return this.jobcategoryService.dropdown().subscribe((res:ResponseModel)=>{
      if(res.status == ResponseStatus.success){
        this.listCategorys = res.result;
        console.log(res.result);
      }
    })
  }

  initialForm(){
    if(this.action == FormStatus.Insert){
      this.recruitmentForm.get('id').reset();
      this.recruitmentForm.get('title').reset();
      this.recruitmentForm.get('description').reset();
      this.recruitmentForm.get('skill').reset();
      this.recruitmentForm.get('categoryId').reset();
      this.recruitmentForm.get('offerfrom').reset();
      this.recruitmentForm.get('offerto').reset();
      this.recruitmentForm.get('requestJob').reset();
      this.recruitmentForm.get('benefit').reset();
      this.recruitmentForm.get('endow').reset();
      this.recruitmentForm.get('timeEnd').reset();
      this.recruitmentForm.get('timeStart').reset();
      this.recruitmentForm.get('quatity').reset();
    }
  }

  getItem(id:number){
    this.recService.item(id).subscribe((res:ResponseModel)=>{
      if(res.status == ResponseStatus.success){
        this.recruitment = res.result;
        this.setDataForm(this.recruitment);
      }
    })
  }

  setDataForm(data:Recruitment){
    this.recruitmentForm.get('id').setValue(data.jobid);
    this.recruitmentForm.get('title').setValue(data.title);
    this.recruitmentForm.get('description').setValue(data.description);
    this.recruitmentForm.get('skill').setValue(data.skill);
    this.recruitmentForm.get('categoryId').setValue(data.category);
    this.recruitmentForm.get('offerfrom').setValue(data.offerfrom);
    this.recruitmentForm.get('offerto').setValue(data.offerto);
    this.recruitmentForm.get('requestJob').setValue(data.requestJob);
    this.recruitmentForm.get('benefit').setValue(data.benefit);
    this.recruitmentForm.get('endow').setValue(data.endow);
    this.recruitmentForm.get('timeEnd').setValue(data.timeEnd);
    this.recruitmentForm.get('timeStart').setValue(data.timeStart);
    this.recruitmentForm.get('quatity').setValue(data.quatity);
  }
}
