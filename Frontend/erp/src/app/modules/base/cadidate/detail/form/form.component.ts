import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { MatDialogRef } from '@angular/material/dialog';
import { ResponseStatus } from 'src/app/core/enums/response-status.enum';
import { ResponseModel } from 'src/app/core/models/response.model';
import { EmployeeService } from '../../../employee/employee.service';
import { InterviewService } from '../../../interview/interview.service';

@Component({
  selector: 'app-form',
  templateUrl: './form.component.html',
  styleUrls: ['./form.component.css']
})
export class FormComponent implements OnInit {

  public interviewForm : FormGroup;
  public checked = false;
  public email : string;
  public cadidateId : number;
  public jobId : number;
  public listEmployee : any;
  constructor(
    private interviewService: InterviewService,
    private employeeSer : EmployeeService,
    private fb: FormBuilder,
    private dialogRef: MatDialogRef<FormComponent>) { }

  ngOnInit(): void {
    this.interviewForm = this.fb.group({
      dateId:[0,Validators.required],
      cadidateId :[0,Validators.required],
      timeDate : ['',Validators.required],
      timeStart :['',Validators.required],
      address :['',Validators.required],
      recruitType : ['',Validators.required],
      time : ['',Validators.required],
      jobId : [0,Validators.required],
      note : ['',Validators.required],
      sendMail :['',Validators.required],
      email: ['',Validators.required],
      employeeid: [0,Validators.required]
    });
    this.getDropdown();
  }

  saveForm(){
    debugger
    var id = this.dialogRef.componentInstance.cadidateId;
    var mail = this.dialogRef.componentInstance.email;
    var jobid = this.dialogRef.componentInstance.jobId;
    this.interviewForm.get('cadidateId').setValue(id);
    this.interviewForm.get('email').setValue(mail);
    this.interviewForm.get('jobId').setValue(jobid);
    var formValue = this.interviewForm.getRawValue();
    var formDate = this.ToFormData(formValue)
    this.interviewService.insert(formDate).subscribe((res:ResponseModel)=>{
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
      if(key ==="timeDate"){
        const month = value.getMonth()+1;
        const day = value.getDate();
        const year = value.getFullYear();
        value = `${month}-${day}-${year}`;
        console.log(value);
      }
      formData.append(key, value);
    }
    return formData;
  }

  getDropdown(){
    this.employeeSer.dropdown().subscribe((res:ResponseModel)=>{
      if(res.status == ResponseStatus.success){
        this.listEmployee = res.result;
      }
    })
  }
}
