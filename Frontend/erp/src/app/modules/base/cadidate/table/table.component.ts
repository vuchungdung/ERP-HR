import { Component, OnInit, Output, EventEmitter } from '@angular/core';
import { PeriodicElement } from '../cadidate.model';
import { MatTableDataSource } from '@angular/material/table';
import { SelectionModel } from '@angular/cdk/collections';
import { MatDialog } from '@angular/material/dialog';
import { FormComponent } from '../form/form.component';
import { DetailComponent } from '../detail/detail.component';
import { Router } from '@angular/router';

@Component({
  selector: 'app-table',
  templateUrl: './table.component.html',
  styleUrls: ['./table.component.css']
})

export class TableComponent implements OnInit {
  @Output() isChecked = new EventEmitter<boolean>();
  status: boolean = true;
  ELEMENT_DATA: any = [];

  displayedColumns: string[] = ['select', 'img', 'name', 'address', 'email', 'phone','degree','experience','source','field'];
  dataSource = new MatTableDataSource<PeriodicElement>(this.ELEMENT_DATA);
  selection = new SelectionModel<PeriodicElement>(true, []);

  isAllSelected() {
    const numSelected = this.selection.selected.length;
    const numRows = this.dataSource.data.length;
    return numSelected === numRows;
  }

  masterToggle() {
    this.isAllSelected() ?
    this.selection.clear() :
    this.dataSource.data.forEach(row => this.selection.select(row));
  }

  checkboxLabel(row?: PeriodicElement): string {
    if (!row) {
      return `${this.isAllSelected() ? 'select' : 'deselect'} all`;
    }
    else{
      //return `${this.selection.isSelected(row) ? 'deselect' : 'select'} row ${row.position + 1}`;
    }
  }

  constructor(
    private dialog: MatDialog,
    private router: Router) {}

  openDialog() {
    const dialogRef = this.dialog.open(FormComponent);
  }

  changeCheckBox($event,row){
    $event ? this.selection.toggle(row) : null;
    return this.isChecked.emit($event.checked);
  }

  openDialogDetail(row?: PeriodicElement){
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
}
