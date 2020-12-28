import { Component, Input, OnInit } from '@angular/core';
import { MatDialog } from '@angular/material/dialog';
import { MatTableDataSource } from '@angular/material/table';
import { ResponseStatus } from 'src/app/core/enums/response-status.enum';
import { PagingModel } from 'src/app/core/models/paging.model';
import { ResponseModel } from 'src/app/core/models/response.model';
import { NotificationService } from 'src/app/shared/services/toastr.service';
import { FormComponentProcess } from './form/form.component';
import { InterviewProcessService } from './detail-process.service';

@Component({
  selector: 'app-detail-process',
  templateUrl: './detail-process.component.html',
  styleUrls: ['./detail-process.component.css']
})
export class DetailProcessComponent implements OnInit {

  @Input() candidateId : number;
  public paging = new PagingModel();
  public searchtext = '';
  public listProcess : any[];
  public item : any;
  public dataSource = new MatTableDataSource();
  public displayedColumns : string[] = ['processname','result','options'];
  public id = '';
  constructor(
    private interviewprocessService : InterviewProcessService,
    private notify : NotificationService,
    private dialog: MatDialog,
  ) { }

  ngOnInit(): void {
    this.getList();
  }

  getList(){
    this.id = this.candidateId.toString();
    this.interviewprocessService.getList(this.paging,this.searchtext,this.id).subscribe((res:ResponseModel)=>{
      if(res.status == ResponseStatus.success){
        this.listProcess = res.result;
        this.dataSource.data = res.result;
      }
    })
  }
  updateProcess(processId:number,applyId:number,id:number){
    const dialogRef = this.dialog.open(FormComponentProcess);
    dialogRef.componentInstance.applyId = applyId;
    dialogRef.componentInstance.processId = processId;
    dialogRef.componentInstance.id = id;
    dialogRef.afterClosed().subscribe(result=>{
      if(result == true){
        this.getList();
        this.notify.showSuccess("Cập nhật thành công!","Thông báo");
      }
    })
  }

  continute(){
    let _item = {
      applyId : 0,
      processId : 0,
      result : 0
    };
    this.listProcess.forEach(function (value) {
      console.log(value)
      _item.applyId = value.applyId;
      _item.processId = value.processId;
      _item.result = value.result;
    }); 
    this.item = _item;
    console.log(this.item);
    var formData = this.ToFormData(this.item);
    this.interviewprocessService.insert(formData).subscribe((res:ResponseModel)=>{
      debugger
      if(res.status == ResponseStatus.success){
        this.getList();
        this.notify.showSuccess("Cập nhật thành công!","Thông báo");
      }
      else{
        this.notify.showSuccess("Thí sinh đã được tuyển!","Thông báo");
      }
    },
    (err)=>{
      this.notify.showWarning("Thí sinh này đã bị loại","Thông báo")
      }
    )
  }
  ToFormData(formValue: any) {
    const formData = new FormData();
    for (const key of Object.keys(formValue)) {
      let value = formValue[key];      
      formData.append(key, value);
    }
    return formData;
  }
}
