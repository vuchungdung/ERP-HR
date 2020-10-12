import { Component, OnInit } from '@angular/core';
import { MatDialog } from '@angular/material/dialog';
import { ToastrService } from 'ngx-toastr';
import { FormStatus } from 'src/app/core/enums/form-status.enum';
import { ResponseStatus } from 'src/app/core/enums/response-status.enum';
import { PagingModel } from 'src/app/core/models/paging.model';
import { ResponseModel } from 'src/app/core/models/response.model';
import { FormComponent } from './form/form.component';
import { ProviderService } from './provider.service';

@Component({
  selector: 'app-provider',
  templateUrl: './provider.component.html',
  styleUrls: ['./provider.component.css']
})
export class ProviderComponent implements OnInit {

  public paging = new PagingModel();
  public searchText = '';
  public dataSource: any;
  public displayedColumns: string[] = ['name', 'link','options'];

  constructor(
    private providerService: ProviderService,
    private dialog: MatDialog,
    private toarts: ToastrService
  ) { }

  ngOnInit(): void {
    this.getList();
  }

  insertProvider(){
    var isCheck = false;
    const dialogRef = this.dialog.open(FormComponent);
    dialogRef.componentInstance.action = FormStatus.Insert;
    dialogRef.componentInstance.isReLoadProvider.subscribe(data=>{
      isCheck = data;
    });
    dialogRef.afterClosed().subscribe(result=>{
      if(result == true){
        if(isCheck == true){
          this.getList();
        }
      }
    })
  }

  updateProvider(id:number){
    var isCheck = false;
    const dialogRef = this.dialog.open(FormComponent);
    dialogRef.componentInstance.id = id;
    dialogRef.componentInstance.action = FormStatus.Update;
    dialogRef.componentInstance.isReLoadProvider.subscribe((data)=>{
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

  deleteProvider(){

  }

  getList(){
    this.providerService.getList(this.paging,this.searchText).subscribe((res:ResponseModel)=>{
      if(res.result == ResponseStatus.success){
        this.dataSource = res.result.items;
        this.paging.length = res.result.totalItems;
      }
    })
  }
}
