import { Component, OnInit } from '@angular/core';
import { MatDialog } from '@angular/material/dialog';
import { ActivatedRoute } from '@angular/router';
import { ToastrService } from 'ngx-toastr';
import { ResponseStatus } from 'src/app/core/enums/response-status.enum';
import { ResponseModel } from 'src/app/core/models/response.model';
import { NotificationService } from 'src/app/shared/services/toastr.service';
import { CadidateDetailService } from './detail.service';
import { FormComponent } from './form/form.component';

@Component({
  selector: 'app-detail',
  templateUrl: './detail.component.html',
  styleUrls: ['./detail.component.css']
})
export class DetailComponent implements OnInit {

  public items : any;

  constructor(
    private route : ActivatedRoute,
    private detailService : CadidateDetailService,
    private dialog: MatDialog,
    private notify: NotificationService) { }

  ngOnInit(): void {
    this.getItem();
  }

  getItem(){
    var id = 0;
    this.route.params.subscribe(param =>{id = param['id']});
    this.detailService.item(id).subscribe((res:ResponseModel) =>{
      if(res.status == ResponseStatus.success){
        this.items = res.result;
        console.log(this.items);
      }
    })
  }

  insertDate(email:string, cadidateId:number,jobId: number){
    const dialogRef = this.dialog.open(FormComponent);
    dialogRef.componentInstance.email = email;
    dialogRef.componentInstance.cadidateId = cadidateId;
    dialogRef.componentInstance.jobId = jobId;
    dialogRef.afterClosed().subscribe(result=>{
      if(result == true){
        this.notify.showSuccess("Đặt lịch ứng tuyển thành công!","Thông báo");
      }
      else{
        this.notify.showWarning("Đặt lịch ứng tuyển thất bại!","Thông báo");
      }
    })
  }
}
