import { ViewChild } from '@angular/core';
import { Component, OnInit } from '@angular/core';
import { MatSort } from '@angular/material/sort';
import { MatTableDataSource } from '@angular/material/table';
import { ResponseStatus } from 'src/app/core/enums/response-status.enum';
import { PagingModel } from 'src/app/core/models/paging.model';
import { ResponseModel } from 'src/app/core/models/response.model';
import { NotificationService } from 'src/app/shared/services/toastr.service';
import { FormComponent } from './form/form.component';
import { SkillService } from './skill.service';

@Component({
  selector: 'app-skill',
  templateUrl: './skill.component.html',
  styleUrls: ['./skill.component.css']
})
export class SkillComponent implements OnInit {

  @ViewChild(FormComponent) form : FormComponent;
  @ViewChild(MatSort, { static: true }) sort: MatSort;

  public paging = new PagingModel();
  public searchText = '';
  public displayedColumns: string[] = ['name','options'];
  public dataSource = new MatTableDataSource();
  public status : boolean;

  constructor(
    private skillService:SkillService,
    private toastr: NotificationService
  ) { }

  ngOnInit(): void {
    this.getList();
  }

  isReload($event : boolean){
    if($event == true){
      this.getList();
    }
  }

  openInsertForm(){
    this.form.openInsertForm();
  }

  openUpdateForm(id:number){
    this.form.openUpdateForm(id);
  }

  deleteItem(){

  }

  getList(){
    this.skillService.getList(this.paging,this.searchText).subscribe((res:ResponseModel)=>{
      if(res.status === ResponseStatus.success){
        this.dataSource.data = res.result.items;
        this.paging.length = res.result.totalItems;
      }
    })
  }
  onPageChange($event){

  }
}
