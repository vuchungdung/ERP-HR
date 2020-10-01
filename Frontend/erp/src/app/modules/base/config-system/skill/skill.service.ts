import { Injectable } from "@angular/core";
import { Observable } from 'rxjs';
import { FilterModel } from 'src/app/core/models/filter.model';
import { PagingModel } from 'src/app/core/models/paging.model';
import { ResponseModel } from 'src/app/core/models/response.model';
import { ApiService } from 'src/app/core/services/api.service';
import { environment } from 'src/environments/environment';
import { Skill } from './skill.model';

@Injectable({providedIn:'root'})
export class SkillService{
  url={
    insert:'/common/skill/insert',
    item:'/common/skill/item',
    getlist:'/common/skill/get-list',
    update:'/common/skill/update',
    delete:'/common/skill/delete',
    dropdown: '/common/skill/drop-down'
  };
  constructor(private api: ApiService){

  }
  insert(model: Skill):Observable<ResponseModel>{
    return this.api.insert(`${environment.apiUrl}${this.url.insert}`,model);
  }
  
  update(model: Skill):Observable<ResponseModel>{
    return this.api.update(`${environment.apiUrl}${this.url.update}`,model);
  }

  getList(paging: PagingModel,searchText:string):Observable<ResponseModel>{
    const filter = new FilterModel();
    filter.text = searchText;
    filter.paging.pageIndex = paging.pageIndex;
    filter.paging.pageSize = paging.pageSize;
    return this.api.getList(`${environment.apiUrl}${this.url.getlist}`,filter);
  }

  item(id:number):Observable<ResponseModel>{
    return this.api.item(`${environment.apiUrl}${this.url.item}`,id);
  }
  dropdown():Observable<ResponseModel>{
    return this.api.dropDown(`${environment.apiUrl}${this.url.dropdown}`)
  }
}