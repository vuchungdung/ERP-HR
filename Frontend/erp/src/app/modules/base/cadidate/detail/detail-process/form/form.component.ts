import { ValueConverter } from '@angular/compiler/src/render3/view/template';
import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, FormGroupName, Validators } from '@angular/forms';
import { MatDialog, MatDialogRef } from '@angular/material/dialog';
import { ResponseStatus } from 'src/app/core/enums/response-status.enum';
import { ResponseModel } from 'src/app/core/models/response.model';
import { InterviewProcessService } from '../detail-process.service';

@Component({
  selector: 'app-form',
  templateUrl: './form.component.html',
  styleUrls: ['./form.component.css']
})
export class FormComponentProcess implements OnInit {

  public interviewProcess : FormGroup;
  public applyId : number;
  public processId : number;
  public id : number;
  constructor(
    private fb : FormBuilder,
    private dialogRef : MatDialogRef<FormComponentProcess>,
    private interviewProcessService : InterviewProcessService
  ) { }

  ngOnInit(): void {
    this.interviewProcess = this.fb.group({
      id :[0,Validators.required],
      processId : ['',Validators.required],
      applyId : ['',Validators.required],
      result : ['',Validators.required]
    });
  }
  
  saveForm(){
    
    var id = this.dialogRef.componentInstance.applyId;
    var pid = this.dialogRef.componentInstance.processId;
    var _id = this.dialogRef.componentInstance.id;
    this.interviewProcess.get('processId').setValue(pid);
    this.interviewProcess.get('applyId').setValue(id);
    this.interviewProcess.get('id').setValue(_id);
    var formValue = this.interviewProcess.getRawValue();
    var formData = this.ToFormData(formValue)
    this.interviewProcessService.update(formData).subscribe((res:ResponseModel)=>{
      if(res.status == ResponseStatus.success){
        this.dialogRef.close(true);
      }
      else{
        this.dialogRef.close(false);
      }
    })
  }
  ToFormData(formValue: any) {
    const formData = new FormData();
    for (const key of Object.keys(formValue)) {
      let value = formValue[key];      
      formData.append(key, value);
    }
    return formData;
  }
}
