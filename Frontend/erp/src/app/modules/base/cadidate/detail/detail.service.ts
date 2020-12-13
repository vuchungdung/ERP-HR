import { Injectable } from "@angular/core";
import { Observable } from 'rxjs';
import { ResponseModel } from 'src/app/core/models/response.model';
import { ApiService } from 'src/app/core/services/api.service';
import { environment } from 'src/environments/environment';

@Injectable({
  providedIn:'root'
})

export class CadidateDetailService{

  constructor(private api: ApiService){}

  url={
    item: '/cadidate/cadidate/item',
    pdfFile: '/common/file/item'
  }

  item(id:number):Observable<ResponseModel>{
    return this.api.item(`${environment.apiUrl}${this.url.item}`,id);
  }
  
  pdfFile(id:number):Observable<ResponseModel>{
    return this.api.item(`${environment.apiUrl}${this.url.pdfFile}`,id);
  }
}