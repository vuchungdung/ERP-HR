import { Component, OnInit } from '@angular/core';
import { PeriodicElement } from '../interview.model';
import { MatTableDataSource } from '@angular/material/table';
import { SelectionModel } from '@angular/cdk/collections';

@Component({
  selector: 'app-table',
  templateUrl: './table.component.html',
  styleUrls: ['./table.component.css']
})

export class TableComponent implements OnInit {

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

  /** Whether the number of selected elements matches the total number of rows. */
  isAllSelected() {
    const numSelected = this.selection.selected.length;
    const numRows = this.dataSource.data.length;
    return numSelected === numRows;
  }

  /** Selects all rows if they are not all selected; otherwise clear selection. */
  masterToggle() {
    this.isAllSelected() ?
    this.selection.clear() :
    this.dataSource.data.forEach(row => this.selection.select(row));
  }

  /** The label for the checkbox on the passed row */
  checkboxLabel(row?: PeriodicElement): string {
    if (!row) {
      return `${this.isAllSelected() ? 'select' : 'deselect'} all`;
    }
    return `${this.selection.isSelected(row) ? 'deselect' : 'select'} row ${row.position + 1}`;
  }

  constructor() { }

  ngOnInit(): void {
  }

}
