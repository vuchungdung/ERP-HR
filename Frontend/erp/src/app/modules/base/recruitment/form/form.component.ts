import { Component, EventEmitter, OnInit, Output, ViewChild } from '@angular/core';
import { FormBuilder, FormGroup, FormsModule, Validators } from '@angular/forms';
import { FormGroupDirective } from '@angular/forms';
import { FormStatus } from 'src/app/core/enums/form-status.enum';
import { ResponseStatus } from 'src/app/core/enums/response-status.enum';
import { ResponseModel } from 'src/app/core/models/response.model';
import { NotificationService } from 'src/app/shared/services/toastr.service';
import { JobCategoryService } from '../../config-system/job-category/job-category.service';
import { SkillService } from '../../config-system/skill/skill.service';
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

  constructor(
    private fb : FormBuilder,
    private recService : RecruitmentService,
    private toastr : NotificationService,
    private skillService: SkillService,
    private jobcategoryService: JobCategoryService
  ) { }

  ngOnInit(): void {
    this.recruitmentForm = this.fb.group({
      title:['',Validators.required],
      description:['',Validators.required],
      skill:['',Validators.required],
      category:['',Validators.required],
      offerfrom:['',Validators.required],
      offerto:['',Validators.required],
      requestJob:['',Validators.required],
      benefit:['',Validators.required],
      endow:['',Validators.required]
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
    debugger
    this.action = FormStatus.Insert;
    this.isShow.emit(false);
    if(this.recruitmentForm.invalid){
      return;
    }
    this.recService.insert(this.recruitmentForm.getRawValue()).subscribe((res:ResponseModel)=>{
      if(res.status == ResponseStatus.success){
        this.isShow.emit(true);
        this.toastr.showSuccess("Đã thêm thành công","Thông báo");
      }
    })
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
}
