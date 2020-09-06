import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { FilterModel } from '../models/filter.model';
import { Observable } from 'rxjs';
import { map } from 'rxjs/operators';
import { ResponseModel } from '../models/response.model';
import { ResponseStatus } from '../enums/response-status.enum';

@Injectable()
export class ApiService {

  constructor(private http: HttpClient){}

  getList(url:string, filter:FilterModel):Observable<ResponseModel>{
    return this.http.post<ResponseModel>(url,filter).pipe(
      map((data:ResponseModel)=>{
        if(data.responseStatus == ResponseStatus.success){
          return data;
        }
        else{
          console.log(data.responseStatus);
        }
      })
    );
  }

  item(url:string, id:number):Observable<ResponseModel>{
    return this.http.get<ResponseModel>(url+"?id="+id).pipe(
      map((data:ResponseModel)=>{
        if(data.responseStatus == ResponseStatus.success){
          return data;
        }
        else{
          console.log(data.responseStatus);
        }
      })
    );
  }

  insert(url, model:any):Observable<ResponseModel>{
    return this.http.post<ResponseModel>(url,model).pipe(
      map((data:ResponseModel)=>{
        if(data.responseStatus == ResponseStatus.success){
          return data;
        }
        else{
          console.log(data.responseStatus);
        }
      })
    );
  }

  update(url, model:any):Observable<ResponseModel>{
    return this.http.put<ResponseModel>(url,model).pipe(
      map((data:ResponseModel) => {
        if(data.responseStatus == ResponseStatus.success){
          return data;
        }
        else{
          console.log(data.responseStatus);
        }
      })
    );
  }

  delete(url, id:number):Observable<ResponseModel>{
    return this.http.delete<ResponseModel>(url+"?id="+id).pipe(
      map((data:ResponseModel) => {
        if(data.responseStatus == ResponseStatus.success){
          return data;
        }
        else{
          console.log(data.responseStatus);
        }
      })
    );
  }
}