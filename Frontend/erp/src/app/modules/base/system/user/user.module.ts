import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { UserComponent } from './user.component';
import { FormComponent } from './form/form.component';
import { TableComponent } from './table/table.component';
import { DetailComponent } from './detail/detail.component';



@NgModule({
  declarations: [UserComponent, FormComponent, TableComponent, DetailComponent],
  imports: [
    CommonModule
  ]
})
export class UserModule { }
