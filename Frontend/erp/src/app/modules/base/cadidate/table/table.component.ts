import { Component, OnInit, Output, EventEmitter } from '@angular/core';
import { Cadidate } from '../cadidate.model';
import { MatTableDataSource } from '@angular/material/table';
import { SelectionModel } from '@angular/cdk/collections';
import { MatDialog } from '@angular/material/dialog';
import { FormComponent } from '../form/form.component';
import { DetailComponent } from '../detail/detail.component';
import { Router } from '@angular/router';
import { CadidateService } from '../cadidate.service';
import { ResponseStatus } from 'src/app/core/enums/response-status.enum';
import { PagingModel } from 'src/app/core/models/paging.model';
import { ResponseModel } from 'src/app/core/models/response.model';

@Component({
  selector: 'app-table',
  templateUrl: './table.component.html',
  styleUrls: ['./table.component.css']
})

export class TableComponent implements OnInit {
  status: boolean = true;
  ELEMENT_DATA: any = [];
  public paging: PagingModel;
  public searchText = '';
  public dataSource : any;

  displayedColumns: string[] = ['select', 'img', 'name', 'address', 'email', 'phone','degree','experience','source','field'];
  selection = new SelectionModel<Cadidate>(true, []);

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

  constructor(
    private dialog: MatDialog,
    private router: Router,
    private cadidateService: CadidateService) {}

  openDialog() {
    const dialogRef = this.dialog.open(FormComponent);
  }

  changeCheckBox($event,row){
    $event ? this.selection.toggle(row) : null;
  }

  openDialogDetail(row?: Cadidate){
    this.router.navigate(['/manager/cadidate/detail'], {});
    const dialogRef = this.dialog.open(DetailComponent,{
      height: '600px',
      width: '1200px',
    });
  }
  openDetail(row){
    this.openDialogDetail(row);
  }

  ngOnInit(): void {
  } 

  getList(){
    return this.cadidateService.getList(this.paging, this.searchText).subscribe((res:ResponseModel)=>{
      if(res.status === ResponseStatus.success){
        this.dataSource = res.result.items;
        this.paging.length = res.result.totalItems;
      }
    })
  }
}
