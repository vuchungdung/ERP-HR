import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { PlanRecruitComponent } from './plan-recruit.component';


const routes: Routes = [
  {
    path: '',
    component: PlanRecruitComponent,
    children: [
      {
        path: '**',
        component: PlanRecruitComponent
      }
    ]
  }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class PlanRecruitRoutingModule { }
