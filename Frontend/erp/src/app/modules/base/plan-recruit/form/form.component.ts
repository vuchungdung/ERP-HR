import { Output } from '@angular/core';
import { ViewChild } from '@angular/core';
import { Component, OnInit } from '@angular/core';
import { EventEmitter } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { FormStatus } from 'src/app/core/enums/form-status.enum';
import { ResponseStatus } from 'src/app/core/enums/response-status.enum';
import { ResponseModel } from 'src/app/core/models/response.model';
import { NotificationService } from 'src/app/shared/services/toastr.service';
import { PlanRecruitService } from '../plan-recruit.service';

@Component({
  selector: 'app-form',
  templateUrl: './form.component.html',
  styleUrls: ['./form.component.css']
})
export class FormComponent implements OnInit {

  @Output() isShow = new EventEmitter<boolean>();
  @Output() reLoad = new EventEmitter<boolean>();
  @ViewChild("ckeditor") ckeditor: any;

  public planForm : FormGroup;
  public action : FormStatus;

  constructor(
    private fb : FormBuilder,
    private notify : NotificationService,
    private planService : PlanRecruitService
  ) { }

  ngOnInit(): void {
    this.planForm = this.fb.group({
      title:['',Validators.required],
      quatity:['',Validators.required],
      status:['',Validators.required],
      note:['',Validators.required],
      timeStart:['',Validators.required],
      timeEnd:['',Validators.required]
    });
    this.action = FormStatus.Unknow;
  }

  saveForm(){
    debugger;
    if(this.planForm.invalid){
      this.notify.showWarning("Vui lòng nhập đầy đủ thông tin!","Thông báo");
      return;
    }
    if(this.action == FormStatus.Insert){
      const formValues = this.planForm.getRawValue();
      const formData = this.ToFormData(formValues);
      this.planService.insert(formData).subscribe((res:ResponseModel)=>{
        if(res.status == ResponseStatus.success){
          this.notify.showSuccess("Thêm mới thành công!","Thông báo");
          this.reLoad.emit(true);
          this.initialForm();
        }
      })
    }
  }
  ToFormData(formValue: any) {
    debugger
    const formData = new FormData();
    for (const key of Object.keys(formValue)) {
      let value = formValue[key];
      if(key === "timeStart" || key ==="timeEnd"){
        const month = value.getMonth()+1;
        const day = value.getDate();
        const year = value.getFullYear();
        value = `${month}-${day}-${year}`;
      }
      formData.append(key, value);
    }
    return formData;
  }
  initialForm(){
    if(this.action == FormStatus.Insert){
      this.isShow.emit(false);
      this.planForm.get('title').reset();
      this.planForm.get('quatity').reset();
      this.planForm.get('status').reset();
      this.planForm.get('note').reset();
      this.ckeditor.instance.setData('');
      this.planForm.get('timeStart').reset();
      this.planForm.get('timeEnd').reset();
    }
    else if(this.action == FormStatus.Update){
    }
  }

  openFormInsert(){
    this.action = FormStatus.Insert;
    this.initialForm();
  }

  showForm(){
    if(this.action == FormStatus.Unknow)
      return false;
    return true;
  }

  onBack(){
    this.action = FormStatus.Unknow;
    this.isShow.emit(true);
  }
}
