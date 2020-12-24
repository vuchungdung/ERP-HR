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
import { SharedModule } from 'src/app/shared/shared.module';
import { FormComponent } from './form/form.component';
import { FullCalendarModule } from '@fullcalendar/angular';
import dayGridPlugin from '@fullcalendar/daygrid'; // a plugin
import timeGridPlugin from '@fullcalendar/timegrid';
import listPlugin from '@fullcalendar/list';
import interactionPlugin from "@fullcalendar/interaction"; // for dateClick
import { InterviewService } from './interview.service';

const routes = [
  {
    path:'',
    component : InterviewComponent,
    pathMatch:'full'
  }
]

FullCalendarModule.registerPlugins([
  dayGridPlugin,
  timeGridPlugin,
  listPlugin,
  interactionPlugin
]);

@NgModule({
  declarations: [InterviewComponent, FormComponent],
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
    SharedModule,
    FullCalendarModule
  ],
  providers:[
    InterviewService
  ]
})
export class InterviewModule { }
