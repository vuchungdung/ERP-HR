import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';
import { ResponseModel } from 'src/app/core/models/response.model';
import { ResponseStatus } from 'src/app/core/enums/response-status.enum';
import { LoginService } from './login.service';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit {

  isLoading = false;
  loginForm : FormGroup;

  constructor(
    private route: Router,
    private authen: LoginService,
    private fb: FormBuilder) { }

  ngOnInit(): void {
    this.loginForm = this.fb.group({
      username: ['', [Validators.required, Validators.maxLength(100)]],
      password: ['', [Validators.required, Validators.maxLength(100)]]
    });
  }



  login(){
    this.isLoading = true;
    if(this.loginForm.invalid){
      console.log("Error");
    }
    this.authen.login(this.loginForm.value).subscribe((response: ResponseModel)=>{
      console.log(response);
      if(response.status == ResponseStatus.success){
        this.isLoading = false;
        localStorage.setItem('token',JSON.stringify(response.result));
        this.route.navigate(['/manager'], {});
      }
    })
  }

}
