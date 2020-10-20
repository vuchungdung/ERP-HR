import { Injectable } from '@angular/core';
import { ToastrService } from 'ngx-toastr';

@Injectable({
  providedIn: 'root'
})
export class NotificationService {

  constructor(private toastr: ToastrService) { }

  showSuccess(message, title){
    this.toastr.success(message, title)
  }

  showWarning(message, title){
    this.toastr.warning(message, title);
  }
  
}