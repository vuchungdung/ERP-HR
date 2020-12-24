import { Injectable } from "@angular/core";
import { Observable } from 'rxjs';
import { FilterModel } from 'src/app/core/models/filter.model';
import { PagingModel } from 'src/app/core/models/paging.model';
import { ResponseModel } from 'src/app/core/models/response.model';
import { ApiService } from 'src/app/core/services/api.service';
import { environment } from 'src/environments/environment';

@Injectable({
  providedIn:'root'
})
export class InterviewService{

  constructor(private api: ApiService){}

  url = {
    insert: '/interview/interviewdate/insert',
    getdate: '/interview/interviewdate/get-date',
  }

  insert(model: FormData):Observable<ResponseModel>{
    return this.api.insert(`${environment.apiUrl}${this.url.insert}`,model);
  }

  dropdown():Observable<ResponseModel>{
    return this.api.dropDown(`${environment.apiUrl}${this.url.getdate}`);
  }
}