import { Component, OnInit, ViewChild } from '@angular/core';
import { FormComponent } from './form/form.component';
import { MatDialog } from '@angular/material/dialog';
import { CadidateService } from './cadidate.service';
import { TableComponent } from './table/table.component';
import { FormStatus } from 'src/app/core/enums/form-status.enum';

@Component({
  selector: 'app-cadidate',
  templateUrl: './cadidate.component.html',
  styleUrls: ['./cadidate.component.css']
})
export class CadidateComponent implements OnInit {

  @ViewChild(TableComponent) readLoadTable : TableComponent;

  public isChecked = false;

  constructor(
    private dialog: MatDialog,
    private cadidateService: CadidateService
    ) {}
  
  checkRecord($event){
    this.isChecked = $event;
  }

  ngOnInit(): void {
  }

  insertCadidate(){
    var isCheck = false;
    const dialogRef = this.dialog.open(FormComponent);
    dialogRef.componentInstance.action = FormStatus.Insert;
    dialogRef.componentInstance.isReLoadCadidate.subscribe(data=>{
      isCheck = data;
    })
    dialogRef.afterClosed().subscribe(result=>{
      if(result == true){
        if(isCheck == true){
          this.readLoadTable.getList();
        }
      }
    })
  }

  openChart(){

  }

  sendMail(){

  }

  addTag(){

  }
}
