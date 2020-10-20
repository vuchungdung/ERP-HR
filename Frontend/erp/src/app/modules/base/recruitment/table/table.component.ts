import { SelectionModel } from '@angular/cdk/collections';
import { Component, OnInit, ViewChild } from '@angular/core';
import { MatDialog } from '@angular/material/dialog';
import { MatSort } from '@angular/material/sort';
import { PagingModel } from 'src/app/core/models/paging.model';
import { Recruitment } from '../recruitment.model';
import { RecruitmentService } from '../recruitment.service';

@Component({
  selector: 'app-table',
  templateUrl: './table.component.html',
  styleUrls: ['./table.component.css']
})
export class TableComponent implements OnInit {
  @ViewChild(MatSort,{static:true}) sort : MatSort;
  public paging = new PagingModel();
  public searchText ='';
  public dataSource: any;

  displayedColumns: string[] = ['select','title','skill','category','offerfrom','offerto','options'];
  selection = new SelectionModel<Recruitment>(true, []);

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

  checkboxLabel(row?: Recruitment): string {
    if (!row) {
      return `${this.isAllSelected() ? 'select' : 'deselect'} all`;
    }
    else{
      return `${this.selection.isSelected(row) ? 'deselect' : 'select'} row ${row.jobid + 1}`;
    }
  }

  changeCheckBox($event,row){
    $event ? this.selection.toggle(row) : null;
  }
  constructor(
    private dialog: MatDialog,
    private recruitService: RecruitmentService
  ) { }

  ngOnInit(): void {

  }
  
  deleteCadidate() {
    
  }

  updateCadidate() {
    
  }


  getList(){
    
  }

  openDetail(id:number){

  }
}
