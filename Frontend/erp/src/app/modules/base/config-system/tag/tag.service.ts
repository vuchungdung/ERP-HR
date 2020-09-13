import { Injectable } from "@angular/core";
import { Observable } from 'rxjs';
import { FilterModel } from 'src/app/core/models/filter.model';
import { PagingModel } from 'src/app/core/models/paging.model';
import { ResponseModel } from 'src/app/core/models/response.model';
import { ApiService } from 'src/app/core/services/api.service';
import { environment } from 'src/environments/environment';
import { Tag } from './tag.model';

@Injectable({
  providedIn: 'root'
})

export class TagService{
  url={
    insert:'/common/tag/insert',
    item:'/common/tag/item',
    getlist:'/common/tag/get-list',
    update:'/common/tag/update',
    delete:'/common/tag/delete'
  };
  constructor(private api: ApiService){

  }
  insert(model: Tag):Observable<ResponseModel>{
    return this.api.insert(`${environment.apiUrl}${this.url.insert}`,model);
  }
  
  update(model: Tag):Observable<ResponseModel>{
    return this.api.update(this.url.update,model);
  }

  getList(paging: PagingModel,searchText:string):Observable<ResponseModel>{
    const filter = new FilterModel();
    filter.text = searchText;
    filter.paging.pageIndex = paging.pageIndex;
    filter.paging.pageSize = paging.pageSize;
    return this.api.getList(this.url.getlist,filter);
  }
}

