import { Injectable } from "@angular/core";
import { HttpClient } from '@angular/common/http';
import { LoginModel } from 'src/app/core/models/login.model';
import { Observable } from 'rxjs';
import { ResponseModel } from 'src/app/core/models/response.model';
import { environment } from 'src/environments/environment';
import { map } from 'rxjs/operators';
import { ResponseStatus } from 'src/app/core/enums/response-status.enum';

@Injectable({
  providedIn: 'root'
})
export class LoginService{
  constructor(private http: HttpClient){}

  login(model: LoginModel): Observable<ResponseModel> {
    return this.http.post<ResponseModel>(`${environment.apiUrl}/api/system/authen/login`, model).pipe(
      map((data:ResponseModel)=>{
        if(data.status == ResponseStatus.success){
          return data;
        }
        else{
          console.log(data.status);
        }
      })
    );
  }
}