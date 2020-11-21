import { Component, OnInit, ViewChild } from '@angular/core';
import { MatTableDataSource } from '@angular/material/table';
import { ResponseStatus } from 'src/app/core/enums/response-status.enum';
import { PagingModel } from 'src/app/core/models/paging.model';
import { ResponseModel } from 'src/app/core/models/response.model';
import { NotificationService } from 'src/app/shared/services/toastr.service';
import { FormComponent } from '../tag/form/form.component';
import { TagService } from './tag.service';

@Component({
  selector: 'app-tag',
  templateUrl: './tag.component.html',
  styleUrls: ['./tag.component.css']
})

export class TagComponent implements OnInit {

  @ViewChild(FormComponent) form : FormComponent;

  public paging = new PagingModel;
  public searchText = '';
  public displayedColumns: string[] = ['name', 'content','options'];
  public dataSource = new MatTableDataSource();

  constructor(
    private tagService: TagService,
    private notify: NotificationService) {}

  
  ngOnInit(): void {
    this.getList();
  }

  isReloadTable($event){
    if($event == true){
      this.getList();
    }
  }

  getList(){
    return this.tagService.getList(this.paging, this.searchText).subscribe((res:ResponseModel)=>{
      if(res.status === ResponseStatus.success){
        this.dataSource.data = res.result.items;
        this.paging.length = res.result.totalItems;
      }
    })
  }

  openInsertForm() {
    this.form.openFormInsert();
  }

  openUpdateForm(id:number){
    this.form.openFormUpdate(id);
  }
  deleteItem(id:number){

  }

  onPageChange($event){
    
  }
}
