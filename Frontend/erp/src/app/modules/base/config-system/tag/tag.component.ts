import { Component, OnInit } from '@angular/core';
import { MatDialog } from '@angular/material/dialog';
import { ResponseStatus } from 'src/app/core/enums/response-status.enum';
import { PagingModel } from 'src/app/core/models/paging.model';
import { ResponseModel } from 'src/app/core/models/response.model';
import { NotificationService } from 'src/app/shared/services/toastr.service';
import { FormComponent } from '../tag/form/form.component';
import { Tag } from './tag.model';
import { TagService } from './tag.service';

@Component({
  selector: 'app-tag',
  templateUrl: './tag.component.html',
  styleUrls: ['./tag.component.css']
})


export class TagComponent implements OnInit {

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

  openDialog() {
    const dialogRef = this.dialog.open(FormComponent);
    
  }

  getList(){
    return this.tagService.getList(this.paging, this.searchText).subscribe((res:ResponseModel)=>{
      if(res.status === ResponseStatus.success){
        this.dataSource = res.result.items;
        this.paging.length = res.result.totalItems;
      }
    })
  }
}
