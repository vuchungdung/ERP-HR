import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { DetailComponent } from './detail.component';
import { FormDetailComponent } from './form-detail/form-detail.component';
import { DetailInfoComponent } from './detail-info/detail-info.component';
import { DetailCvComponent } from './detail-cv/detail-cv.component';
import { DetailApplyHistoryComponent } from './detail-apply-history/detail-apply-history.component';
import { DetailEmailComponent } from './detail-email/detail-email.component';
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
    FormDetailComponent, 
    DetailInfoComponent, 
    DetailCvComponent, 
    DetailApplyHistoryComponent, 
    DetailEmailComponent, 
    DetailInterviewResultComponent
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
  ]
})
export class DetailModule { }
