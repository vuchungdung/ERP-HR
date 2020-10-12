import { Component, OnInit } from '@angular/core';
import { MatDialog } from '@angular/material/dialog';
import { FormStatus } from 'src/app/core/enums/form-status.enum';
import { ResponseStatus } from 'src/app/core/enums/response-status.enum';
import { PagingModel } from 'src/app/core/models/paging.model';
import { ResponseModel } from 'src/app/core/models/response.model';
import { NotificationService } from 'src/app/shared/services/toastr.service';
import { FormComponent } from './form/form.component';
import { JobCategoryService } from './job-category.service';

@Component({
  selector: 'app-job-category',
  templateUrl: './job-category.component.html',
  styleUrls: ['./job-category.component.css']
})
export class JobCategoryComponent implements OnInit {

  public dataSource:any;
  public paging = new PagingModel();
  public searchText = '';
  public displayedColumns: string[] = ['name', 'description','options'];

  constructor(
    private jobcategoryService: JobCategoryService,
    private dialogRef: MatDialog,
    private toastr:NotificationService
  ) { }

  ngOnInit(): void {
    this.getList();
  }

  updateJobCategory(id:number){
    var isCheck = false;
    const dialog = this.dialogRef.open(FormComponent);
    dialog.componentInstance.action = FormStatus.Update;
    dialog.componentInstance.id = id;
    dialog.componentInstance.isReloadJobCategory.subscribe(data=>{
      isCheck = data;
    })

    dialog.afterClosed().subscribe(result=>{
      if(result == true){
        if(isCheck == true){
          this.getList();
        }
      }
    })
  }

  insertJobCategory(){
    var isCheck = false;
    const dialog = this.dialogRef.open(FormComponent);
    dialog.componentInstance.action = FormStatus.Insert;
    dialog.componentInstance.isReloadJobCategory.subscribe(data=>{
      isCheck = data;
    });
    dialog.afterClosed().subscribe(result=>{
      if(result == true){
        if(isCheck == true){
          this.getList();
        }
      }
    })
  }

  deleteJobCategory(){

  }

  getList(){
    this.jobcategoryService.getList(this.paging,this.searchText).subscribe((res:ResponseModel)=>{
      if(res.status == ResponseStatus.success){
        this.dataSource = res.result.items;
        this.paging.length = res.result.totalItems;
      }
    })
  }
}
