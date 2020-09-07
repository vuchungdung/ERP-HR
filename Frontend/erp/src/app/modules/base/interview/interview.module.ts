import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { InterviewComponent } from './interview.component';
import { RouterModule } from '@angular/router';
import { MatButtonModule } from '@angular/material/button';
import { MatSelectModule } from '@angular/material/select';
import { MatTableModule } from '@angular/material/table';
import { MatCheckboxModule } from '@angular/material/checkbox';
import { MatPaginatorModule } from '@angular/material/paginator';
import { MatMenuModule} from '@angular/material/menu';
import { MatIconModule} from '@angular/material/icon';
import { MatDialogModule } from '@angular/material/dialog';
import { DateComponent } from './date/date.component';
import { SharedModule } from 'src/app/shared/shared.module';


const routes = [
  {
    path:'',
    component : InterviewComponent,
    pathMatch:'full'
  }
]

@NgModule({
  declarations: [InterviewComponent, DateComponent],
  imports: [
    CommonModule,
    RouterModule.forChild(routes),
    MatButtonModule,
    MatSelectModule,
    MatTableModule,
    MatCheckboxModule,
    MatPaginatorModule,
    MatMenuModule,
    MatIconModule,
    MatDialogModule,
    SharedModule
  ]
})
export class InterviewModule { }
