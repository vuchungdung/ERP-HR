import { Component, OnInit, ViewChild } from '@angular/core';
import { MatDialog } from '@angular/material/dialog';
import { FormStatus } from 'src/app/core/enums/form-status.enum';
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

  paging = new PagingModel();
  searchText = '';

  constructor(
    private dialog: MatDialog,
    private tagService: TagService,
    private toastr: NotificationService) {}

  isLoad: boolean;
  ngOnInit(): void {
    this.getList();
  }

  displayedColumns: string[] = ['name', 'content','options'];
  dataSource : any;

  getList(){
    return this.tagService.getList(this.paging, this.searchText).subscribe((res:ResponseModel)=>{
      if(res.status === ResponseStatus.success){
        this.dataSource = res.result.items;
        this.paging.length = res.result.totalItems;
      }
    })
  }

  insertDialog() {
    var isCheck = false;
    const dialogRef = this.dialog.open(FormComponent);
    dialogRef.componentInstance.isReloadData.subscribe((data)=>{
      isCheck = data;
    })
    dialogRef.afterClosed().subscribe(result =>{
      if(result==true){
        if(isCheck == true){
          this.getList();
        }
      }
    })
  }

  updateDialog(id:number){
    const dialogRef = this.dialog.open(FormComponent);
    dialogRef.componentInstance.id = id;
    dialogRef.componentInstance.action = FormStatus.Update;
  }
}
