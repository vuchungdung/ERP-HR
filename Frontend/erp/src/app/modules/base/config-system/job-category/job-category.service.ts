import { Injectable } from "@angular/core";
import { Observable } from 'rxjs';
import { FilterModel } from 'src/app/core/models/filter.model';
import { PagingModel } from 'src/app/core/models/paging.model';
import { ResponseModel } from 'src/app/core/models/response.model';
import { ApiService } from 'src/app/core/services/api.service';
import { environment } from 'src/environments/environment';
import { JobCategory } from './job-category.model';

@Injectable({
  providedIn:'root'
})
export class JobCategoryService{


  constructor(private api: ApiService){}

  url = {
    insert:'/common/jobcategory/insert',
    update:'/common/jobcategory/update',
    getlist:'/common/jobcategory/get-list',
    delete:'/common/jobcategory/delete',
    item:'/common/jobcategory/item'
  }

  insert(model:JobCategory):Observable<ResponseModel>{
    return this.api.insert(`${environment.apiUrl}${this.url.insert}`,model);
  }

  update(model: JobCategory):Observable<ResponseModel>{
    return this.api.update(`${environment.apiUrl}${this.url.insert}`,model);
  }

  delete(id: number):Observable<ResponseModel>{
    return this.api.delete(`${environment.apiUrl}${this.url.insert}`,id);
  }

  getList(paging:PagingModel,searchText:string):Observable<ResponseModel>{
    const filter = new FilterModel();
    filter.text = searchText;
    filter.paging.pageIndex = paging.pageIndex;
    filter.paging.pageSize = paging.pageSize;
    return this.api.getList(`${environment.apiUrl}${this.url.getlist}`,filter);
  }

  item(id:number):Observable<ResponseModel>{
    return this.api.item(`${environment.apiUrl}${this.url.insert}`,id);
  }
}