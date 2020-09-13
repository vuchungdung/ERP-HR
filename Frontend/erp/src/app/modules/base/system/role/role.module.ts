import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RoleComponent } from './role.component';
import { FormComponent } from './form/form.component';
import { TableComponent } from './table/table.component';



@NgModule({
  declarations: [RoleComponent, FormComponent, TableComponent],
  imports: [
    CommonModule
  ]
})
export class RoleModule { }
