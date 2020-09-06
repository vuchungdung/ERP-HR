import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit {

  constructor(private route: Router) { }

  ngOnInit(): void {
  }

  isLoading = false;

  login(){
    this.isLoading = true;
    setTimeout(()=>{
      this.route.navigate(['/manager'], {});
    },3000);
  }

}
