import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { CadidateComponent } from './cadidate/cadidate.component';
import { InterviewComponent } from './interview/interview.component';



@NgModule({
  declarations: [CadidateComponent, InterviewComponent],
  imports: [
    CommonModule
  ]
})
export class DetailModule { }
