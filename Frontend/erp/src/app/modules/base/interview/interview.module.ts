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
import { TableComponent } from './table/table.component';
import { MatDialogModule } from '@angular/material/dialog';
import { FormComponent } from './form/form.component';

const routes = [
  {
    path:'',
    component:InterviewComponent,
    pathMatch:'full'
  }
]

@NgModule({
  declarations: [InterviewComponent, TableComponent, FormComponent],
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
    MatDialogModule
  ]
})
export class InterviewModule { }
