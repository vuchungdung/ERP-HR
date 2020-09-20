import { NgModule } from '@angular/core';
import { appInterceptors } from './app.Interceptors';
import { ApiService } from '../core/services/api.service';
import { AuthenticationGuard } from '../core/guards/authentication.guard';
@NgModule({
  providers:[
    ApiService
  ]
})
export class SharedModule { }
