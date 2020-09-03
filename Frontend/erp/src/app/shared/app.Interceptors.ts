import { HTTP_INTERCEPTORS } from '@angular/common/http';
import { NetworkInterceptor } from '../core/interceptor/network.interceptor';
import { HeaderInterceptor } from '../core/interceptor/header.interceptor';
import { ErrorInterceptor } from '../core/interceptor/error.interceptor';

export const appInterceptors = [
  { provide: HTTP_INTERCEPTORS, useClass: NetworkInterceptor, multi: true },
  { provide: HTTP_INTERCEPTORS, useClass: HeaderInterceptor, multi: true },
  { provide: HTTP_INTERCEPTORS, useClass: ErrorInterceptor, multi: true },
];