import { Injectable } from "@angular/core";
import { Observable } from 'rxjs';
import { FilterModel } from 'src/app/core/models/filter.model';
import { PagingModel } from 'src/app/core/models/paging.model';
import { ResponseModel } from 'src/app/core/models/response.model';
import { ApiService } from 'src/app/core/services/api.service';
import { environment } from 'src/environments/environment';
import { Recruitment } from './recruitment.model';

@Injectable({
  providedIn:'root'
})
export class RecruitmentService{

  constructor(private api: ApiService){}

  url = {
    insert: '/recruitment/jobdescription/insert',
    update: '/recruitment/jobdescription/update',
    delete: '/recruitment/jobdescription/delete',
    item: '/recruitment/jobdescription/item',
    getlist: '/recruitment/jobdescription/get-list',
    dropdown: '/recruitment/jobdescription/dropdown'
  }

  insert(model: FormData):Observable<ResponseModel>{
    return this.api.insert(`${environment.apiUrl}${this.url.insert}`,model);
  }

  update(model: FormData):Observable<ResponseModel>{
    return this.api.update(`${environment.apiUrl}${this.url.update}`,model);
  }

  item(id:number):Observable<ResponseModel>{
    return this.api.item(`${environment.apiUrl}${this.url.item}`,id);
  }

  delete(id:number){
    return this.api.delete(`${environment.apiUrl}${this.url.delete}`,id);
  }
  
  dropdown():Observable<ResponseModel>{
    return this.api.dropDown(`${environment.apiUrl}${this.url.dropdown}`);
  }

  getList(paging: PagingModel,searchText:string):Observable<ResponseModel>{
    const filter = new FilterModel();
    filter.text = searchText;
    filter.paging.pageIndex = paging.pageIndex;
    filter.paging.pageSize = paging.pageSize;
    return this.api.getList(`${environment.apiUrl}${this.url.getlist}`,filter);
  }
}