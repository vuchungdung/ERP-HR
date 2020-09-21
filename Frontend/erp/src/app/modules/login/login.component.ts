import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';
import { ResponseModel } from 'src/app/core/models/response.model';
import { ResponseStatus } from 'src/app/core/enums/response-status.enum';
import { LoginService } from './login.service';
import { NotificationService } from 'src/app/shared/services/toastr.service';

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
    private fb: FormBuilder,
    private toastr: NotificationService) { }

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
      this.isLoading = false;
      this.toastr.showWarning("Vui lòng nhập tài khoản và mật khẩu","");     
    }
    this.authen.login(this.loginForm.value).subscribe(
      (response: ResponseModel)=>{
        if(response.status == ResponseStatus.success){
          this.isLoading = false;
          localStorage.setItem('token',JSON.stringify(response.result));
          this.route.navigate(['/manager'], {});
        }
        else{
          this.isLoading = false;
          this.toastr.showWarning("Tài khoản hoặc mật khẩu không hợp lệ","")
        }
      },
      (err)=>{
        this.isLoading = false;
        this.toastr.showWarning("Không có kết nối Server","")
      }
    )
  }

}
