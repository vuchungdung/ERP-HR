import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { BaseComponent } from './base.component';
import { DashboardComponent } from './dashboard/dashboard.component';


const routes: Routes = [
  {
    path: '',
    component: BaseComponent,
    children: [
      {
        path: '',
        loadChildren: () => import('../base/dashboard/dashboard.module').then(m => m.DashboardModule),
        pathMatch: 'full'
      },
      {
        path: 'interview',
        loadChildren: () => import('../base/interview/interview.module').then(m => m.InterviewModule),
        pathMatch: 'full'
      },
      {
        path: 'system',
        loadChildren: () => import('../base/system/system.module').then(m => m.SystemModule),
        pathMatch: 'full'
      },
      {
        path: 'cadidate',
        loadChildren: () => import('../base/cadidate/cadidate.module').then(m => m.CadidateModule)
      },
      {
        path: 'common',
        loadChildren: () => import('../base/config-system/config-system.module').then(m => m.ConfigSystemModule)
      },
      {
        path: '**',
        component: DashboardComponent
      }
    ]
  }
];


@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class BaseRoutingModule { }
