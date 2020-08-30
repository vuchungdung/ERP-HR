import { Component, OnInit } from '@angular/core';
import { MatDialog } from '@angular/material/dialog';
import { FormComponent } from './form/form.component';


@Component({
  selector: 'app-interview',
  templateUrl: './interview.component.html',
  styleUrls: ['./interview.component.css']
})
export class InterviewComponent implements OnInit {
  
  isCheck = false;

  constructor(public dialog: MatDialog) {}

  openDialog() {
    const dialogRef = this.dialog.open(FormComponent);

    dialogRef.afterClosed().subscribe(result => {
      console.log(`Dialog result: ${result}`);
    });
  }
  
  hello($event){
    this.isCheck = $event;
    console.log(this.isCheck+"...");
  }

  ngOnInit(): void {
    
  }
}
