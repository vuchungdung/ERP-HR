import { Component, OnInit, ViewChild } from '@angular/core';
import { FormComponent } from './form/form.component';
import { CadidateService } from './cadidate.service';
import { FormStatus } from 'src/app/core/enums/form-status.enum';
import { SelectionModel } from '@angular/cdk/collections';
import { MatSort } from '@angular/material/sort';
import { Router } from '@angular/router';
import { ResponseStatus } from 'src/app/core/enums/response-status.enum';
import { PagingModel } from 'src/app/core/models/paging.model';
import { ResponseModel } from 'src/app/core/models/response.model';
import { Cadidate } from './cadidate.model';
import { PageEvent } from '@angular/material/paginator';
import { MatTableDataSource } from '@angular/material/table';

@Component({
  selector: 'app-cadidate',
  templateUrl: './cadidate.component.html',
  styleUrls: ['./cadidate.component.css']
})
export class CadidateComponent implements OnInit {

  @ViewChild(FormComponent) form : FormComponent;
  @ViewChild(MatSort, { static: true }) sort: MatSort;

  public paging = new PagingModel();
  public searchText = '';
  public dataSource = new MatTableDataSource();
  public displayedColumns: string[] = ['img', 'name', 'address', 'email', 'phone','degree','experience','major','source','status','tag','options'];
  public selection = new SelectionModel<Cadidate>(true, []);
  public status:boolean = true;
  public action : FormStatus = FormStatus.Unknow;
  public currentPageSize = this.paging.pageSize;

  constructor(
    private cadidateService: CadidateService,
    private router : Router
    ) {}
  
  ngOnInit(): void {
    this.getList();
  }  

  insertCadidate(){
    this.form.openFormInsert();
  }

  showTable(){
    return this.status;
  }
  isShowTable($event){
    this.status = $event;
  }
  deleteCadidate() {
    
  }

  updateCadidate() {
    
  }

  reloadTable($event : boolean){
    if($event == true){
      this.getList();
    }
  }

  getList(){
    this.cadidateService.getList(this.paging, this.searchText).subscribe((res:ResponseModel)=>{
      if(res.status === ResponseStatus.success){
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

  openFormDetail(row : Cadidate){
    this.router.navigate(['/manager/cadidate/detail/'+row.cadidateId]);
    console.log(row);
    this.status = false;
  }

}
