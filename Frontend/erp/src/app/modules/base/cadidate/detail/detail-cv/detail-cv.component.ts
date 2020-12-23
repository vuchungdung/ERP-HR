import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-detail-cv',
  templateUrl: './detail-cv.component.html',
  styleUrls: ['./detail-cv.component.css']
})
export class DetailCvComponent implements OnInit {

  public src : any;

  constructor() { }

  ngOnInit(): void {
    
  }

  getPath(filepath: string){
    debugger
    this.src = filepath;
  }

}