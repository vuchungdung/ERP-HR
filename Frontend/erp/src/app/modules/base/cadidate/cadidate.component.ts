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
import { RecruitmentService } from '../recruitment/recruitment.service';
import { ProcessService } from '../config-system/process/process.service';

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
  public displayedColumns: string[] = ['img', 'name', 'address', 'email', 'phone','source','job','status','options'];
  public selection = new SelectionModel<Cadidate>(true, []);
  public status:boolean = true;
  public action : FormStatus = FormStatus.Unknow;
  public currentPageSize = this.paging.pageSize;
  public processId = 0;
  public jobId = 0;
  public listProcess : any;
  public listJob : any;
  constructor(
    private cadidateService: CadidateService,
    private router : Router,
    private jobService : RecruitmentService,
    private processService : ProcessService
    ) {}
  
  ngOnInit(): void {
    this.getList();
    this.dropdownJob();
    this.dropdownProcess();
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

  // getList(){
  //   this.cadidateService.getList(this.paging, this.searchText,0,0).subscribe((res:ResponseModel)=>{
  //     if(res.status === ResponseStatus.success){
  //       this.dataSource.data = res.result.items;
  //       console.log(res.result.items);
  //       this.paging.length = res.result.totalItems;
  //     }
  //   })
  // }
  
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
    this.router.navigate(['/manager/cadidate/detail/'+row.candidateId]);
    this.status = false;
  }
  dropdownProcess(){
    this.processService.dropdown().subscribe((res:ResponseModel)=>{
      if(res.status == ResponseStatus.success){
        this.listProcess = res.result;
      }
    })
  }
  dropdownJob(){
    this.jobService.dropdown().subscribe((res:ResponseModel)=>{
      if(res.status == ResponseStatus.success){
        this.listJob = res.result;
      }
    })
  }


  getList(){
    this.cadidateService.getList(this.paging, this.searchText,this.processId,this.jobId).subscribe((res:ResponseModel)=>{
      if(res.status === ResponseStatus.success){
        this.dataSource.data = res.result.items;
        console.log(res.result.items);
        this.paging.length = res.result.totalItems;
      }
    })
  }
}
