import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ConfigSystemComponent } from './config-system.component';
import { RouterModule, Routes } from '@angular/router';
import { MatSidenavModule } from '@angular/material/sidenav';


const routes: Routes = [
  {
    path:'',
    component : ConfigSystemComponent,
    pathMatch:'full'
  }
]

@NgModule({
  declarations: [ConfigSystemComponent],
  imports: [
    CommonModule,
    RouterModule.forChild(routes),
    MatSidenavModule
  ]
})
export class ConfigSystemModule { }
