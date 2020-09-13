import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ConfigSystemComponent } from './config-system.component';
import { RouterModule, Routes } from '@angular/router';
import { MatSidenavModule } from '@angular/material/sidenav';
import { ConfigSystemRoutingModule } from './config-system-routing.module';
import { ApiService } from 'src/app/core/services/api.service';

@NgModule({
  declarations: [ConfigSystemComponent],
  imports: [
    CommonModule,
    MatSidenavModule,
    ConfigSystemRoutingModule
  ],
  providers:[
    ApiService
  ]
})
export class ConfigSystemModule { }
