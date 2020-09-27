import { HttpClient, HttpEventType } from '@angular/common/http';
import { Output } from '@angular/core';
import { EventEmitter } from '@angular/core';
import { Component, OnInit } from '@angular/core';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';
import { MatDialogRef } from '@angular/material/dialog';
import { FormStatus } from 'src/app/core/enums/form-status.enum';
import { ResponseStatus } from 'src/app/core/enums/response-status.enum';
import { ResponseModel } from 'src/app/core/models/response.model';
import { environment } from 'src/environments/environment';
import { Cadidate } from '../cadidate.model';
import { CadidateService } from '../cadidate.service';

@Component({
  selector: 'app-form',
  templateUrl: './form.component.html',
  styleUrls: ['./form.component.css']
})
export class FormComponent implements OnInit {

  @Output() onUploadFinished = new EventEmitter();
  @Output() isReLoadCadidate = new EventEmitter();

  public cadidateForm : FormGroup;
  public progress: number;
  public _url: any;
  public item: Cadidate;
  public id: number;
  public action: FormStatus;

  constructor(
    private fb: FormBuilder,
    private http: HttpClient,
    private dialogRef: MatDialogRef<FormComponent>,
    private cadidateService: CadidateService
  ) { }

  url = {
    upload: '/common/file/upload',
  }  

  ngOnInit(): void {
    this.cadidateForm = this.fb.group({
      name:['',Validators.required],
      dob:['',Validators.required],
      phone:['',Validators.required],
      email:['',Validators.required],
      address:['',Validators.required],
      degree:['',Validators.required],
      university:['',Validators.required],
      major:['',Validators.required],
      jobcategory:['',Validators.required],
      applyDate:['',Validators.required],
      provider:['',Validators.required],
      skill:['',Validators.required],
      applydate:['',Validators.required],
      experience:['',Validators.required],
    });
    this.initCadidateForm();
  }
  uploadFile(files){
    if (files.length === 0) {
      return;
    }
    
    let fileToUpload = <File>files[0];
    const formData = new FormData();
    formData.append('file', fileToUpload, fileToUpload.name);
    
    this.http.post(`${environment.apiUrl}${this.url.upload}`, formData, {reportProgress: true, observe: 'events'})
      .subscribe(event => {
        if (event.type === HttpEventType.UploadProgress)
          this.progress = Math.round(100 * event.loaded / event.total);
        else if (event.type === HttpEventType.Response) {
          this.onUploadFinished.emit(event.body);
          this._url = event.body;
          console.log(this._url);
        }
      });
  }
  initCadidateForm(){
    const action = this.dialogRef.componentInstance.action;
    if(action == FormStatus.Insert){
      this.cadidateForm.get('name').reset();
      this.cadidateForm.get('dob').reset();
      this.cadidateForm.get('email').reset();
      this.cadidateForm.get('address').reset();
      this.cadidateForm.get('degree').reset();
      this.cadidateForm.get('phone').reset();
      this.cadidateForm.get('skill').reset();
      this.cadidateForm.get('provider').reset();
      this.cadidateForm.get('applydate').reset();
      this.cadidateForm.get('jobcategory').reset();
      this.cadidateForm.get('experience').reset();
      this.cadidateForm.get('university').reset();
      this.cadidateForm.get('major').reset();
      this.cadidateForm.get('experience').reset();
    }
    else if(action == FormStatus.Update){
      const id = this.dialogRef.componentInstance.id;
    }
  }

  saveForm(){
    const action = this.dialogRef.componentInstance.action;
    if(this.cadidateForm.invalid){
      return;
    }
    if(action == FormStatus.Insert){
      this.cadidateService.insert(this.cadidateForm.getRawValue()).subscribe((res: ResponseModel)=>{
        if(res.status == ResponseStatus.success){
          this.isReLoadCadidate.emit(true);
        }
        else{
          console.log("Error Insert");
        }
      });
    }
  }

  getItem(){

  }

  setDataForm(){

  }
}
