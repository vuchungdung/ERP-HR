import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { BaseComponent } from './base.component';
import { HeaderComponent } from 'src/app/shared/components/header/header.component';
import { SidenavComponent } from 'src/app/shared/components/sidenav/sidenav.component';
import { MatTabsModule } from '@angular/material/tabs';
import { MatButtonModule } from '@angular/material/button';
import { MatMenuModule } from '@angular/material/menu';
import { BaseRoutingModule } from './base-routing.module';


@NgModule({
  declarations: [BaseComponent,HeaderComponent,SidenavComponent],
  imports: [
    CommonModule,
    MatTabsModule,
    MatButtonModule,
    MatMenuModule,
    BaseRoutingModule
  ]
})
export class BaseModule { }
