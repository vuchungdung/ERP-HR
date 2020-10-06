import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { JobCategoryComponent } from './job-category.component';
import { FormComponent } from './form/form.component';



@NgModule({
  declarations: [JobCategoryComponent, FormComponent],
  imports: [
    CommonModule
  ]
})
export class JobCategoryModule { }
