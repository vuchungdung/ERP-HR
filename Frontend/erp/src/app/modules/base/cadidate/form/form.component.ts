import { HttpClient, HttpEventType } from '@angular/common/http';
import { Output } from '@angular/core';
import { EventEmitter } from '@angular/core';
import { Component, OnInit } from '@angular/core';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';
import { MatDialogRef } from '@angular/material/dialog';
import { FormStatus } from 'src/app/core/enums/form-status.enum';
import { ResponseStatus } from 'src/app/core/enums/response-status.enum';
import { ResponseModel } from 'src/app/core/models/response.model';
import { AppValidator } from 'src/app/core/validators/app.validators';
import { environment } from 'src/environments/environment';
import { SkillService } from '../../config-system/skill/skill.service';
import { Cadidate} from '../cadidate.model';
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
  public item: Cadidate;
  public id: number;
  public action: FormStatus;
  public img: string;
  public pdf: any;
  public resFile : any;
  public listFile = [];
  public json:string;
  public listOps: any[];

  constructor(
    private fb: FormBuilder,
    private http: HttpClient,
    private dialogRef: MatDialogRef<FormComponent>,
    private cadidateService: CadidateService,
    private skillService: SkillService
  ) { }

  url = {
    upload: '/common/file/upload'
  }  

  ngOnInit(): void {
    this.cadidateForm = this.fb.group({
      name:['demo',Validators.required],
      dob:['',[Validators.required]],
      gender:[0,Validators.required],
      phone:['demo',Validators.required],
      email:['demo@gmail.com',[Validators.required,Validators.email]],
      address:['demo',Validators.required],
      degree:['demo',Validators.required],
      university:['demo',Validators.required],
      major:['demo',Validators.required],
      categoryid:['',[Validators.required,AppValidator.number]],
      providerid:['',[Validators.required,AppValidator.number]],
      skill:['',Validators.required],
      applydate:['',[Validators.required]],
      experience:['demo',Validators.required],
    });
    //this.initCadidateForm();
    this.dropdown();
  }
  uploadFile(files){
    const formData = new FormData();
    if (files.length === 0) {
      return;
    }
    let fileToUpload = <File>files[0];
    this.listFile.push(fileToUpload);
    formData.append('file', fileToUpload, fileToUpload.name);
    this.http.post(`${environment.apiUrl}${this.url.upload}`, formData, {reportProgress: true, observe: 'events'})
      .subscribe(event => {
        if (event.type === HttpEventType.Response) {        
          this.onUploadFinished.emit(event.body);
          this.resFile = event.body;
          if(this.resFile.result.fileType == ".pdf"){
            this.pdf = this.resFile.result;
            this.pdf.name = this.pdf.fileName;
            this.pdf.size = this.pdf.fileSize;
          }
          else if(this.resFile.result.fileType != ".pdf"){
            this.img = this.resFile.result.dbPath;
          }
          console.log(this.listFile);
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
      this.cadidateForm.get('providerid').reset();
      this.cadidateForm.get('applydate').reset();
      this.cadidateForm.get('categoryid').reset();
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
    debugger
    const action = this.dialogRef.componentInstance.action;
    if(this.cadidateForm.invalid){
      return;
    }
    if(action == FormStatus.Insert){
      const formValues = this.cadidateForm.getRawValue();
      const formData = this.ToFormData(formValues);
      this.listFile.forEach(file => {
        formData.append('files', file, file.name);
      });
      this.cadidateService.insert(formData).subscribe((res:ResponseModel)=>{

      })
    }
  }

  getItem(){

  }

  setDataForm(){

  }

  createImgPath(){
    return `https://localhost:44379/${this.img}`;
  }

  ToFormData(formValue: any) {
    const formData = new FormData();
    for (const key of Object.keys(formValue)) {
      let value = formValue[key];
      if(key === "dob" || key ==="applydate"){
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
    console.log(formData.get('category'))
    return formData;
  }

  dropdown(){
    return this.skillService.dropdown().subscribe((res:ResponseModel)=>{
      if(res.status == ResponseStatus.success){
        this.listOps = res.result;
        console.log(this.listOps);
      }
    })
  }
}
