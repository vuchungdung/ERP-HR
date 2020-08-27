import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
@NgModule({
  declarations: [ //đối với component, khai báo những component của module này sử dụng
    AppComponent
  ],
  imports: [ //đối với module, import những module mà module này cần dùng
    BrowserModule,
    AppRoutingModule,
    BrowserAnimationsModule
  ],
  providers: [], //đối với services,class,.....,khai báo những services, class mà module này có thể dùng
  bootstrap: [AppComponent]
})
export class AppModule { }
