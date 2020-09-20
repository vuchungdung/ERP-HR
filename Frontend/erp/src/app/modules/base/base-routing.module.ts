import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { AuthenticationGuard } from 'src/app/core/guards/authentication.guard';
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
        canActivate:[AuthenticationGuard],
        canActivateChild:[AuthenticationGuard],
        loadChildren: () => import('../base/interview/interview.module').then(m => m.InterviewModule),
        pathMatch: 'full'
      },
      {
        path: 'system',
        canActivate:[AuthenticationGuard],
        canActivateChild:[AuthenticationGuard],
        loadChildren: () => import('../base/system/system.module').then(m => m.SystemModule),
        pathMatch: 'full'
      },
      {
        path: 'cadidate',
        canActivate:[AuthenticationGuard],
        canActivateChild:[AuthenticationGuard],
        loadChildren: () => import('../base/cadidate/cadidate.module').then(m => m.CadidateModule)
      },
      {
        path: 'common',
        canActivate:[AuthenticationGuard],
        canActivateChild:[AuthenticationGuard],
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
