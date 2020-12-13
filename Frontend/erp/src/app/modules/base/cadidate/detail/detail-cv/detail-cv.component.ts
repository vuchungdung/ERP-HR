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
    this.src = "https://vadimdez.github.io/ng2-pdf-viewer/assets/pdf-test.pdf";
  }

}
