import { Input } from '@angular/core';
import { Component, OnInit, ViewChild } from '@angular/core';
import { PageEvent } from '@angular/material/paginator';
import { MatSort } from '@angular/material/sort';
import { MatTableDataSource } from '@angular/material/table';
import { ResponseStatus } from 'src/app/core/enums/response-status.enum';
import { FilterModel } from 'src/app/core/models/filter.model';
import { PagingModel } from 'src/app/core/models/paging.model';
import { ResponseModel } from 'src/app/core/models/response.model';
import { WorkHistoryService } from './detail-workhistory.service';

@Component({
  selector: 'app-detail-workhistory',
  templateUrl: './detail-workhistory.component.html',
  styleUrls: ['./detail-workhistory.component.css']
})
export class DetailWorkhistoryComponent implements OnInit {

  @ViewChild(MatSort, { static: true }) sort: MatSort;
  @Input() candidateId : number;
  public paging = new PagingModel();
  public searchText = '';
  public id = '';
  public dataSource = new MatTableDataSource();
  public currentPageSize = this.paging.pageSize;
  public displayedColumns: string[] = ['timeStart', 'timeEnd', 'company', 'position'];
  constructor(
    private service : WorkHistoryService
  ) { }

  ngOnInit(): void {
    this.getList();
  }

  getList(){
    this.id = this.candidateId.toString();
    this.service.getList(this.paging,this.searchText,this.id).subscribe((res:ResponseModel)=>{
      if(res.status == ResponseStatus.success){
        this.dataSource.data = res.result.items;
        this.paging.length = res.result.totalItems;
      }
    })

  }
  onPageChange(page:PageEvent){
    this.paging.pageSize = page.pageSize;
    this.paging.pageIndex = page.pageIndex+1;
    if (page.pageSize !== this.currentPageSize) {
      this.currentPageSize = page.pageSize;
      this.paging.pageIndex = 1;
    }
    this.getList();
  }
}
