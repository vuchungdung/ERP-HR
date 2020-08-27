import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { InterviewComponent } from './interview.component';
import { RouterModule } from '@angular/router';

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
    RouterModule.forChild(routes)
  ]
})
export class InterviewModule { }
