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
    console.log("https://localhost:44379/wwwroot/cadidate-cv/"+filepath);
    this.src = "https://localhost:44379/wwwroot/cadidate-cv/"+filepath;
  }

}