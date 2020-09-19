import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { HttpClientModule, HTTP_INTERCEPTORS } from '@angular/common/http';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { CommonModule } from '@angular/common';
import { SharedModule } from './shared/shared.module';
import { ApiService } from './core/services/api.service';
import { appInterceptors } from './shared/app.Interceptors';
import { HeaderInterceptor } from './core/interceptors/header.interceptor';
@NgModule({
  declarations: [ //đối với component, khai báo những component của module này sử dụng
    AppComponent
  ],
  imports: [ //đối với module, import những module mà module này cần dùng
    BrowserModule,
    AppRoutingModule,
    BrowserAnimationsModule,
    CommonModule,
    FormsModule,
    ReactiveFormsModule,
    HttpClientModule
  ],
  providers: [ApiService,{ provide: HTTP_INTERCEPTORS, useClass: HeaderInterceptor, multi: true }], //đối với services,class,.....,khai báo những services, class mà module này có thể dùng
  bootstrap: [AppComponent]
})
export class AppModule { }
