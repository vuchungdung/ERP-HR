import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FileCvComponent } from './file-cv.component';
import { FormComponent } from './form/form.component';



@NgModule({
  declarations: [FileCvComponent, FormComponent],
  imports: [
    CommonModule
  ]
})
export class FileCvModule { }
