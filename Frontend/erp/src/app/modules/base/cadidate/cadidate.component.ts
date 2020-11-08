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

  @ViewChild(FormComponent) form : FormComponent;

  public status:boolean = true;
  public action : FormStatus = FormStatus.Unknow;
  constructor(
    private cadidateService: CadidateService
    ) {}
  
  checkRecord($event){
    
  }

  ngOnInit(): void {

  }

  insertCadidate(){
    this.form.openFormInsert();
  }

  openChart(){

  }

  sendMail(){

  }

  addTag(){

  }

  showTable(){
    return this.status;
  }
  isShowTable($event){
    debugger;
    this.status = $event;
  }
}
