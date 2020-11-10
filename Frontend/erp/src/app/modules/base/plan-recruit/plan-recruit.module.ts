import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { PlanRecruitComponent } from './plan-recruit.component';
import { FormComponent } from './form/form.component';



@NgModule({
  declarations: [PlanRecruitComponent, FormComponent],
  imports: [
    CommonModule
  ]
})
export class PlanRecruitModule { }
