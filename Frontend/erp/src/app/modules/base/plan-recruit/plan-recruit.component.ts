import { Component, OnInit, ViewChild } from '@angular/core';
import { FormComponent } from './form/form.component';

@Component({
  selector: 'app-plan-recruit',
  templateUrl: './plan-recruit.component.html',
  styleUrls: ['./plan-recruit.component.css']
})
export class PlanRecruitComponent implements OnInit {

  public displayedColumns: string[] = ['select','title','skill','category','offerfrom','offerto','options'];
  public status : boolean = true;

  @ViewChild(FormComponent) form : FormComponent;

  constructor() { }

  ngOnInit(): void {
  }

  insertPlan(){
    this.form.openFormInsert();
  }

  showTable(){
    return this.status;
  }
  isShowTable($event){
    debugger;
    this.status = $event;
  }
}
