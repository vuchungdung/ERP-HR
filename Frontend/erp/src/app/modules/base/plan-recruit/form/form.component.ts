import { Output } from '@angular/core';
import { Component, OnInit } from '@angular/core';
import { EventEmitter } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { FormStatus } from 'src/app/core/enums/form-status.enum';

@Component({
  selector: 'app-form',
  templateUrl: './form.component.html',
  styleUrls: ['./form.component.css']
})
export class FormComponent implements OnInit {

  @Output() isShow = new EventEmitter<boolean>();

  public planForm : FormGroup;
  public action : FormStatus;

  constructor(
    private fb : FormBuilder
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

  initialForm(){
    if(this.action == FormStatus.Insert){
      this.isShow.emit(false);
      this.planForm.get('title').reset();
      this.planForm.get('quatity').reset();
      this.planForm.get('status').reset();
      this.planForm.get('note').reset();
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
