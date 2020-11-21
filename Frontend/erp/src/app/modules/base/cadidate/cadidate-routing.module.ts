import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { CadidateComponent } from './cadidate.component';
import { DetailComponent } from './detail/detail.component';


const routes: Routes = [
  {
    path: '',
    component: CadidateComponent,
    pathMatch:'full'
  }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class CadidateRoutingModule { }
