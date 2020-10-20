import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ConfigSystemComponent } from './config-system.component';
import { RouterModule, Routes } from '@angular/router';
import { MatSidenavModule } from '@angular/material/sidenav';
import { ConfigSystemRoutingModule } from './config-system-routing.module';
import { ApiService } from 'src/app/core/services/api.service';
import { SharedModule } from 'src/app/shared/shared.module';
import { HTTP_INTERCEPTORS } from '@angular/common/http';
import { HeaderInterceptor } from 'src/app/core/interceptors/header.interceptor';

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
