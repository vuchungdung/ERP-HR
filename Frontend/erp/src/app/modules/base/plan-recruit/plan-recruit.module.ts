import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { PlanRecruitComponent } from './plan-recruit.component';
import { FormComponent } from './form/form.component';
import { Routes } from '@angular/router';
import { RouterModule } from '@angular/router';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { MatButtonModule } from '@angular/material/button';
import { MatCheckboxModule } from '@angular/material/checkbox';
import { MatNativeDateModule } from '@angular/material/core';
import { MatDatepickerModule } from '@angular/material/datepicker';
import { MatDialogModule } from '@angular/material/dialog';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatIconModule } from '@angular/material/icon';
import { MatInputModule } from '@angular/material/input';
import { MatMenuModule } from '@angular/material/menu';
import { MatPaginatorModule } from '@angular/material/paginator';
import { MatRadioModule } from '@angular/material/radio';
import { MatSelectModule } from '@angular/material/select';
import { MatTableModule } from '@angular/material/table';
import { CKEditorModule } from 'ckeditor4-angular';
import { ApiService } from 'src/app/core/services/api.service';
import { NotificationService } from 'src/app/shared/services/toastr.service';
import { PlanRecruitService } from './plan-recruit.service';

const routes: Routes = [
  {
    path: '',
    component: PlanRecruitComponent,
    pathMatch:'full'
  }
];

@NgModule({
  declarations: [PlanRecruitComponent, FormComponent],
  imports: [
    CommonModule,CommonModule,
    FormsModule,
    ReactiveFormsModule,
    MatButtonModule,
    MatSelectModule,
    MatTableModule,
    MatCheckboxModule,
    MatPaginatorModule,
    MatMenuModule,
    MatIconModule,
    MatDialogModule,
    MatFormFieldModule,
    MatNativeDateModule,
    MatDatepickerModule,
    MatRadioModule,
    MatInputModule,
    CKEditorModule,
    RouterModule.forChild(routes)
  ],
  providers:[
    ApiService,
    NotificationService,
    PlanRecruitService
  ]
})
export class PlanRecruitModule { }
