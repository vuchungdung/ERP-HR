export class PagingModel {
  pageSize: number;
  pageIndex: number;
  pageSizeOptions: any[];
  length: number;

  constructor() {
    this.pageSize = 5;
    this.pageIndex = 1;
    this.pageSizeOptions = [5, 10, 20, 50];
    this.length = 0;

  }
}