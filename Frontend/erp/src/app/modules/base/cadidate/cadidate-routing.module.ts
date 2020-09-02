import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { DetailComponent } from './detail/detail.component';
import { CadidateComponent } from './cadidate.component';


const routes: Routes = [
  {
    path: '',
    component: CadidateComponent,
    children: [
      {
        path: 'detail',
        loadChildren: () => import('../cadidate/detail/detail.module').then(m => m.DetailModule),
        pathMatch: 'full'
      },
      {
        path: '**',
        component: CadidateComponent
      }
    ]
  }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class CadidateRoutingModule { }
