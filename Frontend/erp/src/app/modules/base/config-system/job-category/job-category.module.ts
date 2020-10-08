import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { JobCategoryComponent } from './job-category.component';
import { FormComponent } from './form/form.component';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { MatButtonModule } from '@angular/material/button';
import { MatDialogModule } from '@angular/material/dialog';
import { MatIconModule } from '@angular/material/icon';
import { MatTableModule } from '@angular/material/table';
import { RouterModule } from '@angular/router';
import { Routes } from '@angular/router';
import { JobCategoryService } from './job-category.service';

const routes: Routes = [
  {
    path:'',
    component : JobCategoryComponent,
    pathMatch:'full'
  }
]

@NgModule({
  declarations: [JobCategoryComponent, FormComponent],
  imports: [
    CommonModule,
    RouterModule.forChild(routes),
    MatTableModule,
    MatIconModule,
    MatButtonModule,
    MatDialogModule,
    FormsModule,
    ReactiveFormsModule
  ],
  providers:[
    JobCategoryService
  ]
})
export class JobCategoryModule { }
