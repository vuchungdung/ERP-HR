import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { DetailComponent } from './detail.component';
import { DetailInterviewResultComponent } from './detail-interview-result/detail-interview-result.component';
import { RouterModule } from '@angular/router';
import { MatTabsModule } from '@angular/material/tabs';
import { MatSelectModule } from '@angular/material/select';
import { MatTableModule } from '@angular/material/table';
import { MatCheckboxModule } from '@angular/material/checkbox';
import { MatPaginatorModule } from '@angular/material/paginator';
import { MatMenuModule } from '@angular/material/menu';
import { MatIconModule } from '@angular/material/icon';
import { MatDialogModule } from '@angular/material/dialog';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatDatepickerModule } from '@angular/material/datepicker';
import { MatNativeDateModule } from '@angular/material/core';
import { MatRadioModule } from '@angular/material/radio';
import { MatInputModule } from '@angular/material/input';
import { ReactiveFormsModule, FormsModule } from '@angular/forms';
import { MatButtonModule } from '@angular/material/button';
import { CadidateDetailService } from './detail.service';
import { FormComponent } from './form/form.component';
import { NotificationService } from 'src/app/shared/services/toastr.service';
import { ApiService } from 'src/app/core/services/api.service';
import { InterviewService } from '../../interview/interview.service';
import { PdfViewerModule } from 'ng2-pdf-viewer';
import { DetailAwardComponent } from './detail-award/detail-award.component';
import { DetailEducationComponent } from './detail-education/detail-education.component';
import { DetailWorkhistoryComponent } from './detail-workhistory/detail-workhistory.component';
import { DetailProcessComponent } from './detail-process/detail-process.component';
import { DetailCvComponent } from './detail-cv/detail-cv.component';
import { EmployeeService } from '../../employee/employee.service';
import { SharedModule } from 'src/app/shared/shared.module';
import { WorkHistoryService } from './detail-workhistory/detail-workhistory.service';
import { InterviewProcessService } from './detail-process/detail-process.service';
import { FormComponentProcess } from '../detail/detail-process/form/form.component';


const routes = [
  {
    path:'',
    component:DetailComponent,
    pathMatch:'full'
  }
]

@NgModule({
  declarations: [
    DetailComponent,
    DetailInterviewResultComponent,
    FormComponent, 
    DetailAwardComponent,
    DetailEducationComponent, 
    DetailWorkhistoryComponent, 
    DetailProcessComponent, 
    DetailCvComponent,
    FormComponentProcess
  ],
  imports: [
    CommonModule,
    MatTabsModule,
    MatButtonModule,
    RouterModule.forChild(routes),
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
    PdfViewerModule,
    SharedModule
  ],
  providers:[
    CadidateDetailService,
    NotificationService,
    ApiService,
    InterviewService,
    EmployeeService,
    WorkHistoryService,
    InterviewProcessService
  ]
})
export class DetailModule { }
