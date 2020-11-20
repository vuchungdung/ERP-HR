export class PagingModel {
  pageSize: number;
  pageIndex: number;
  pageSizeOptions: any[];
  length: number;

  constructor() {
    this.pageSize = 10;
    this.pageIndex = 1;
    this.pageSizeOptions = [10, 20, 50, 100];
    this.length = 0;
  }
}