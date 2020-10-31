import { ViewChild } from '@angular/core';
import { Component, OnInit } from '@angular/core';
import { FormComponent } from './form/form.component';

@Component({
  selector: 'app-recruitment',
  templateUrl: './recruitment.component.html',
  styleUrls: ['./recruitment.component.css']
})
export class RecruitmentComponent implements OnInit {

  @ViewChild(FormComponent) form: FormComponent;
  public status:boolean = true;
  constructor() { }

  ngOnInit(): void {

  }
  OnInsertClick(){
    this.form.insertRecruit();
  }

  showTable(){
    return this.status;
  }
  changeStatus($event){
    this.status = $event;
  }
}
