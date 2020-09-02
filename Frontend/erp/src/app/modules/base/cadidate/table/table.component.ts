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
  ELEMENT_DATA: PeriodicElement[] = [
    {position: 1, name: 'Hydrogen', weight: 1.0079, symbol: 'Senior Web Developer'},
    {position: 2, name: 'Helium', weight: 4.0026, symbol: 'Senior Web Developer'},
    {position: 3, name: 'Lithium', weight: 6.941, symbol: 'Senior Web Developer'},
    {position: 4, name: 'Beryllium', weight: 9.0122, symbol: 'Senior Web Developer'},
    {position: 5, name: 'Boron', weight: 10.811, symbol: 'Senior Web Developer'},
    {position: 6, name: 'Carbon', weight: 12.0107, symbol: 'Senior Web Developer'},
    {position: 7, name: 'Nitrogen', weight: 14.0067, symbol: 'Senior Web Developer'},
    {position: 8, name: 'Oxygen', weight: 15.9994, symbol: 'Senior Web Developer'},
    {position: 9, name: 'Fluorine', weight: 18.9984, symbol: 'Senior Web Developer'},
    {position: 10, name: 'Neon', weight: 20.1797, symbol: 'Senior Web Developer'},
  ];

  displayedColumns: string[] = ['select', 'position', 'name', 'weight', 'symbol', 'demo1','demo2','demo3','options'];
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
      return `${this.selection.isSelected(row) ? 'deselect' : 'select'} row ${row.position + 1}`;
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
