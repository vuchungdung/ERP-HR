import { HttpClient, HttpEventType } from '@angular/common/http';
import { Output } from '@angular/core';
import { EventEmitter } from '@angular/core';
import { Component, OnInit } from '@angular/core';
import { FormGroup, FormBuilder } from '@angular/forms';
import { environment } from 'src/environments/environment';

@Component({
  selector: 'app-form',
  templateUrl: './form.component.html',
  styleUrls: ['./form.component.css']
})
export class FormComponent implements OnInit {

  @Output() public onUploadFinished = new EventEmitter();

  cadidateForm : FormGroup;
  public progress: number;
  public _url: any;

  
  constructor(
    private fb: FormBuilder,
    private http: HttpClient
  ) { }

    url = {
      upload: '/common/file/upload'
    }

  ngOnInit(): void {
    this.cadidateForm = this.fb.group({
      id:[0],
      name:[''],
      dob:[''],
      date:['']
    });
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
}
