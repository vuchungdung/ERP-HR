import { Component, OnInit } from '@angular/core';
import { MatDialog } from '@angular/material/dialog';
import { ToastrService } from 'ngx-toastr';
import { FormStatus } from 'src/app/core/enums/form-status.enum';
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

  public paging = new PagingModel();
  public searchText = '';
  public isLoad : boolean;
  public displayedColumns: string[] = ['name','options'];
  public dataSource : any;

  constructor(
    private skillService:SkillService,
    private dialog: MatDialog,
    private toastr: NotificationService
  ) { }

  ngOnInit(): void {
    this.getList();
  }

  insertSkill(){
    var isCheck = false;
    const dialogRef = this.dialog.open(FormComponent);
    dialogRef.componentInstance.action = FormStatus.Insert;
    dialogRef.componentInstance.isReLoadSkill.subscribe(data=>{
      isCheck = data;
    })
    dialogRef.afterClosed().subscribe(result=>{
      if(result == true){
        if(isCheck == true){
          this.toastr.showSuccess("Thêm mới thành công","Thông báo");
          this.getList();
        }
        else{
          this.toastr.showWarning("Thêm mới thất bại","Thông báo");
        }
      }
    })
  }

  updateSkill(id:number){
    var isCheck = false;
    const dialogRef = this.dialog.open(FormComponent);
    dialogRef.componentInstance.action = FormStatus.Update;
    dialogRef.componentInstance.id = id
    dialogRef.componentInstance.isReLoadSkill.subscribe(data=>{
      isCheck = data;
    })
    dialogRef.afterClosed().subscribe(result=>{
      if(result == true){
        if(isCheck == true){
          this.toastr.showSuccess("Cập nhật thành công","Thông báo");
          this.getList();
        }
        else{
          this.toastr.showWarning("Cập nhật thất bại","Thông báo");
        }
      }
    })
  }

  deleteSkill(){

  }

  getList(){
    return this.skillService.getList(this.paging,this.searchText).subscribe((res:ResponseModel)=>{
      if(res.status === ResponseStatus.success){
        this.dataSource = res.result.items;
        this.paging.length = res.result.totalItems;
      }
    })
  }
}
