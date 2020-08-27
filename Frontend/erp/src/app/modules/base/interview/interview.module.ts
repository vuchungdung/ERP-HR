import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { InterviewComponent } from './interview.component';
import { RouterModule } from '@angular/router';
import { MatButtonModule } from '@angular/material/button';
import { MatSelectModule } from '@angular/material/select';


const routes = [
  {
    path:'',
    component:InterviewComponent,
    pathMatch:'full'
  }
]

@NgModule({
  declarations: [InterviewComponent],
  imports: [
    CommonModule,
    RouterModule.forChild(routes),
    MatButtonModule,
    MatSelectModule
    
  ]
})
export class InterviewModule { }
