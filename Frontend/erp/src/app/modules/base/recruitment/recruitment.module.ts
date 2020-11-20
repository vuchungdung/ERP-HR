import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RecruitmentComponent } from './recruitment.component';
import { FormComponent } from './form/form.component';
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
import { RecruitmentRoutingModule } from './recruitment-routing.module';
import { CKEditorModule } from 'ckeditor4-angular';
import { RecruitmentService } from './recruitment.service';
import { JobCategoryService } from '../config-system/job-category/job-category.service';
import { SkillService } from '../config-system/skill/skill.service';
import { NotificationService } from 'src/app/shared/services/toastr.service';
import { SharedModule } from 'src/app/shared/shared.module';

@NgModule({
  declarations: [RecruitmentComponent, FormComponent],
  imports: [
    CommonModule,
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
    RecruitmentRoutingModule,
    CKEditorModule,
    SharedModule
  ],
  providers:[
    RecruitmentService,
    SkillService,
    JobCategoryService,
    NotificationService
  ]
})
export class RecruitmentModule { }
