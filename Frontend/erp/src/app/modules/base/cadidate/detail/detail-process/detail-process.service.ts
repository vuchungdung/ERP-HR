import { Injectable } from "@angular/core";
import { Observable } from "rxjs";
import { FilterModel } from "src/app/core/models/filter.model";
import { PagingModel } from "src/app/core/models/paging.model";
import { ResponseModel } from "src/app/core/models/response.model";
import { ApiService } from "src/app/core/services/api.service";
import { environment } from "src/environments/environment";

@Injectable({providedIn:'root'})

export class InterviewProcessService{

  constructor(
    private api : ApiService
  ){

  }

  url = {
    insert : '/interview/interviewprocess/insert',
    update : '/interview/interviewprocess/update',
    getList : '/interview/interviewprocess/get-list',
    delete : '/interview/interviewprocess/delete',
    item : '/interview/interviewprocess/item'
  }

  insert(model: FormData):Observable<ResponseModel>{
    return this.api.insert(`${environment.apiUrl}${this.url.insert}`,model);
  }

  update(model : FormData):Observable<ResponseModel>{
    return this.api.update(`${environment.apiUrl}${this.url.update}`,model);
  }

  item(id : number):Observable<ResponseModel>{
    return this.api.item(`${environment.apiUrl}${this.url.item}`,id);
  }

  getList(model : PagingModel, searchText : string, candidateId: string){
    const filter = new FilterModel();
    filter.candidateId = candidateId;
    filter.paging.pageIndex = model.pageIndex;
    filter.paging.pageSize = model.pageSize;
    filter.text = searchText;
    return this.api.getList(`${environment.apiUrl}${this.url.getList}`,filter);
  }
}