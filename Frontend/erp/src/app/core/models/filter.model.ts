import { PagingModel } from './paging.model';

export class FilterModel{
  text:string;
  paging: PagingModel;
  candidateId : string;
  jobId : number;
  processId: number;
  constructor(){
    this.text = '';
    this.paging = new PagingModel();
    this.candidateId = '';
    this.processId = 0;
    this.jobId = 0;
  }
}