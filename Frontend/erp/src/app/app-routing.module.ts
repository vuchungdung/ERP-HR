import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { LoginComponent } from './modules/login/login.component';


const routes: Routes = [
  {
    path:'login',
    loadChildren: () => import('../app/modules/login/login.module').then(m=>m.LoginModule)
  },
  {
    path: 'manager',
    loadChildren: () => import('../app/modules/base/base.module').then(m => m.BaseModule),
  },
  {
    path: '**',
    component: LoginComponent
  }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
