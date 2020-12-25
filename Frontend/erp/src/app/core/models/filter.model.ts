import { PagingModel } from './paging.model';

export class FilterModel{
  text:string;
  paging: PagingModel;
  candidateId : string;

  constructor(){
    this.text = '';
    this.paging = new PagingModel();
    this.candidateId = '';
  }
}