import { ViewChild } from '@angular/core';
import { Component, OnInit } from '@angular/core';
import { MatDialog } from '@angular/material/dialog';
import { ActivatedRoute } from '@angular/router';
import { ResponseStatus } from 'src/app/core/enums/response-status.enum';
import { ResponseModel } from 'src/app/core/models/response.model';
import { NotificationService } from 'src/app/shared/services/toastr.service';
import { DetailCvComponent } from './detail-cv/detail-cv.component';
import { CadidateDetailService } from './detail.service';
import { FormComponent } from './form/form.component';

@Component({
  selector: 'app-detail',
  templateUrl: './detail.component.html',
  styleUrls: ['./detail.component.css']
})
export class DetailComponent implements OnInit {

  @ViewChild(DetailCvComponent) form : DetailCvComponent;

  public items : any;
  constructor(
    private route : ActivatedRoute,
    private detailService : CadidateDetailService,
    private dialog: MatDialog,
    private notify: NotificationService) { }

  ngOnInit(): void {
    this.getItem();
    this.getDetailCv();
  }

  getId(){
    var id = 0;
    this.route.params.subscribe(param =>{id = param['id']});
    return id;
  }

  getItem(){
    var id = this.getId();
    this.detailService.item(id).subscribe((res:ResponseModel) =>{
      if(res.status == ResponseStatus.success){
        this.items = res.result;
      }
    })
  }

  getDetailCv(){
    var id = this.getId();
    this.detailService.pdfFile(id).subscribe((res:ResponseModel)=>{
      if(res.status == ResponseStatus.success){
      }
    })
  }

  insertDate(email:string, candidateId:number,jobId: number){
    const dialogRef = this.dialog.open(FormComponent);
    dialogRef.componentInstance.email = email;
    dialogRef.componentInstance.candidateId = candidateId;
    dialogRef.componentInstance.jobId = jobId;
    dialogRef.afterClosed().subscribe(result=>{
      if(result == true){
        this.notify.showSuccess("Đặt lịch ứng tuyển thành công!","Thông báo");
      }
    })
  }
}
