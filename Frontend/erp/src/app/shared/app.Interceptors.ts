import { HTTP_INTERCEPTORS } from '@angular/common/http';
import { NetworkInterceptor } from '../core/interceptors/network.interceptor';
import { HeaderInterceptor } from '../core/interceptors/header.interceptor';
import { ErrorInterceptor } from '../core/interceptors/error.interceptor';

export const appInterceptors = [
  { provide: HTTP_INTERCEPTORS, useClass: HeaderInterceptor, multi: true },
];