import { Component, OnInit, ViewChild } from '@angular/core';
import { FormComponent } from './form/form.component';
import { CadidateService } from './cadidate.service';
import { FormStatus } from 'src/app/core/enums/form-status.enum';
import { SelectionModel } from '@angular/cdk/collections';
import { MatSort } from '@angular/material/sort';
import { Router } from '@angular/router';
import { ResponseStatus } from 'src/app/core/enums/response-status.enum';
import { PagingModel } from 'src/app/core/models/paging.model';
import { ResponseModel } from 'src/app/core/models/response.model';
import { Cadidate } from './cadidate.model';

@Component({
  selector: 'app-cadidate',
  templateUrl: './cadidate.component.html',
  styleUrls: ['./cadidate.component.css']
})
export class CadidateComponent implements OnInit {

  @ViewChild(FormComponent) form : FormComponent;
  @ViewChild(MatSort, { static: true }) sort: MatSort;

  public paging = new PagingModel();
  public searchText = '';
  public dataSource : any;
  public displayedColumns: string[] = ['select', 'img', 'name', 'address', 'email', 'phone','degree','experience','category','source','status','tag','options'];
  public selection = new SelectionModel<Cadidate>(true, []);
  public status:boolean = true;
  public action : FormStatus = FormStatus.Unknow;

  constructor(
    private cadidateService: CadidateService
    ) {}
  
  ngOnInit(): void {
    this.getList();
  }  

  insertCadidate(){
    this.form.openFormInsert();
  }

  showTable(){
    return this.status;
  }
  isShowTable($event){
    debugger;
    this.status = $event;
  }
  
  isAllSelected() {
    const numSelected = this.selection.selected.length;
    const numRows = 0;
    return numSelected === numRows;
  }

  masterToggle() {
    this.isAllSelected() ?
    this.selection.clear() :
    this.dataSource.data.forEach(row => this.selection.select(row));
  }

  checkboxLabel(row?: Cadidate): string {
    if (!row) {
      return `${this.isAllSelected() ? 'select' : 'deselect'} all`;
    }
    else{
      return `${this.selection.isSelected(row) ? 'deselect' : 'select'} row ${row.id + 1}`;
    }
  }

  changeCheckBox($event,row){
    $event ? this.selection.toggle(row) : null;
  }

  deleteCadidate() {
    
  }

  updateCadidate() {
    
  }

  reloadTable($event : boolean){
    if($event == true){
      this.getList();
    }
  }

  getList(){
    return this.cadidateService.getList(this.paging, this.searchText).subscribe((res:ResponseModel)=>{
      if(res.status === ResponseStatus.success){
        this.dataSource = res.result.items;
        console.log(this.dataSource);
        this.paging.length = res.result.totalItems;
      }
    })
  }
}
