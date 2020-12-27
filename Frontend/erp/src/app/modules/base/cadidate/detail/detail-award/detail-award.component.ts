import { Component, Input, OnInit, ViewChild } from '@angular/core';
import { PageEvent } from '@angular/material/paginator';
import { MatSort } from '@angular/material/sort';
import { MatTableDataSource } from '@angular/material/table';
import { ResponseStatus } from 'src/app/core/enums/response-status.enum';
import { PagingModel } from 'src/app/core/models/paging.model';
import { ResponseModel } from 'src/app/core/models/response.model';
import { AwardService } from './detail-award.service';

@Component({
  selector: 'app-detail-award',
  templateUrl: './detail-award.component.html',
  styleUrls: ['./detail-award.component.css']
})
export class DetailAwardComponent implements OnInit {

  @ViewChild(MatSort, { static: true }) sort: MatSort;
  @Input() candidateId : number;
  public id : string;
  public paging = new PagingModel();
  public searchText = "";
  public dataSource = new MatTableDataSource();
  public currentPageSize = this.paging.pageSize;
  public displayedColumns: string[] = ['_From', '_To', 'title', 'institute'];

  constructor(
    private awardService : AwardService
  ) { }

  ngOnInit(): void {
    this.getList();
  }
  getList(){
    this.id = this.candidateId.toString();
    this.awardService.getList(this.paging,this.searchText,this.id).subscribe((res:ResponseModel)=>{
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
