import { Injectable } from '@angular/core';
import { HttpInterceptor, HttpRequest, HttpHandler, HttpEvent, HttpHeaders } from '@angular/common/http';
import { Observable } from 'rxjs';

@Injectable()
export class HeaderInterceptor implements HttpInterceptor {
  intercept(req: HttpRequest<any>, next: HttpHandler): Observable<HttpEvent<any>> {
    const token = localStorage.getItem('token');
    var obtoken = JSON.parse(token);
    const modified = this.setHeader(req,this.jwtToken(obtoken.accessToken));
    return next.handle(modified);
  }

  setHeader(request,token){
    let headers = new HttpHeaders();
    headers = headers.append('Authorization',token);
    headers.append('Content-Type', 'multipart/form-data');
    headers.append('Accept', 'application/json');
    return request.clone( {headers });
  }
  private jwtToken(token):string{
    return 'bearer '+token;
  }
}