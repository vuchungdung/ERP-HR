import { SelectionModel } from '@angular/cdk/collections';
import { Component, OnInit, ViewChild } from '@angular/core';
import { FormComponent } from './form/form.component';
import { PlanRecruit } from './plan-recruit.model';

@Component({
  selector: 'app-plan-recruit',
  templateUrl: './plan-recruit.component.html',
  styleUrls: ['./plan-recruit.component.css']
})
export class PlanRecruitComponent implements OnInit {

  public displayedColumns: string[] = ['select','title','skill','category','offerfrom','offerto','options'];
  public status : boolean = true;
  public selection = new SelectionModel<PlanRecruit>(true, []);
  public dataSource : any;

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

  isAllSelected() {
    const numSelected = this.selection.selected.length;
    const numRows = 0;
    return numSelected === numRows;
  }

  masterToggle() {
    this.isAllSelected() ?
    this.selection.clear() :
    this.dataSource.data.forEach(row => this.selection.select(row));
  }

  checkboxLabel(row?: PlanRecruit): string {
    if (!row) {
      return `${this.isAllSelected() ? 'select' : 'deselect'} all`;
    }
    else{
      return `${this.selection.isSelected(row) ? 'deselect' : 'select'} row ${row.planId + 1}`;
    }
  }

  changeCheckBox($event,row){
    $event ? this.selection.toggle(row) : null;
  }
  deletePlanRecruit(){

  }
  updatePlanRecruit(){

  }
  
}
