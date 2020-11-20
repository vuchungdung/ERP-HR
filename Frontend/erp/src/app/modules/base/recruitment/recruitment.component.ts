import { ViewChild } from '@angular/core';
import { Component, OnInit } from '@angular/core';
import { PageEvent } from '@angular/material/paginator';
import { MatSort } from '@angular/material/sort';
import { MatTableDataSource } from '@angular/material/table';
import { ResponseStatus } from 'src/app/core/enums/response-status.enum';
import { PagingModel } from 'src/app/core/models/paging.model';
import { ResponseModel } from 'src/app/core/models/response.model';
import { NotificationService } from 'src/app/shared/services/toastr.service';
import { FormComponent } from './form/form.component';
import { Recruitment } from './recruitment.model';
import { RecruitmentService } from './recruitment.service';

@Component({
  selector: 'app-recruitment',
  templateUrl: './recruitment.component.html',
  styleUrls: ['./recruitment.component.css']
})
export class RecruitmentComponent implements OnInit {

  @ViewChild(FormComponent) form: FormComponent;
  @ViewChild(MatSort, { static: true }) sort: MatSort;
  
  public status:boolean = true;
  public dataSource = new MatTableDataSource();
  public displayedColumns: string[] = ['title', 
                                        'skill',
                                         'category','offerto',
                                         'offerfrom',
                                         'timeEnd',
                                         'timeStart','quatity','options'];
  public paging = new PagingModel();
  public keyword = '';
  public currentPageSize = this.paging.pageSize;
  constructor(
    private recService: RecruitmentService,
    private notify: NotificationService
  ) { }

  ngOnInit(): void {
    this.getList();
  }

  OnInsertClick(){
    this.form.OpenFormInsert();
  }
  
  OnUpdateClick(id : number){
    this.form.OpenFormUpdate(id);
  }

  showTable(){
    return this.status;
  }

  changeStatus($event:boolean){
    if($event == true){
      this.getList();
    }
    this.status = $event;
  }

  getList(){
    this.recService.getList(this.paging,this.keyword).subscribe((res:ResponseModel)=>{
      if(res.status == ResponseStatus.success){
        this.dataSource.data = res.result.items;
        console.log(res.result.items);
        this.paging.length = res.result.totalItems;
      }
    })
  }

  updateItem(id:number){
    this.form.OpenFormUpdate(id);
  }

  deleteItem(id:number){
    this.recService.delete(id).subscribe((res:ResponseModel)=>{
      if(res.status == ResponseStatus.success){
        this.notify.showSuccess("Xóa thành công!","Thông báo");
      }
      else{
        this.notify.showWarning("Không thể xóa được!","Thông báo");
      }
    })
  }
  onPageChange(page: PageEvent){
    this.paging.pageSize = page.pageSize;
    this.paging.pageIndex = page.pageIndex+1;
    if (page.pageSize !== this.currentPageSize) {
      this.currentPageSize = page.pageSize;
      this.paging.pageIndex = 1;
    }
    this.getList();
  }
}
