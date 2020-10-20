import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { PlanRecruitComponent } from './plan-recruit.component';
import { FormComponent } from './form/form.component';
import { TableComponent } from './table/table.component';



@NgModule({
  declarations: [PlanRecruitComponent, FormComponent, TableComponent],
  imports: [
    CommonModule
  ]
})
export class PlanRecruitModule { }
