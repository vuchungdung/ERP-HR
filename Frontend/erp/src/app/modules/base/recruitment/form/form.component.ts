import { Component, EventEmitter, OnInit, Output, ViewChild } from '@angular/core';
import { FormBuilder, FormGroup, FormsModule, Validators } from '@angular/forms';
import { FormGroupDirective } from '@angular/forms';
import { FormStatus } from 'src/app/core/enums/form-status.enum';

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
  constructor(
    private fb : FormBuilder
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
  }

  showForm(){
    if(this.action == FormStatus.Unknow)
      return false;
    return true;
  }
  
  insertRecruit(){
    this.action = FormStatus.Insert;
    this.isShow.emit(false);
  }

  onBack(){
    this.action = FormStatus.Unknow;
    this.isShow.emit(true);
  }
}
