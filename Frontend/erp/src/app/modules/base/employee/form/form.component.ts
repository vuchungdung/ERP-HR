import { EventEmitter, Output } from '@angular/core';
import { Component, OnInit } from '@angular/core';
import { FormBuilder } from '@angular/forms';
import { Validators } from '@angular/forms';
import { FormGroup } from '@angular/forms';
import { FormStatus } from 'src/app/core/enums/form-status.enum';
import { ResponseStatus } from 'src/app/core/enums/response-status.enum';
import { ResponseModel } from 'src/app/core/models/response.model';
import { NotificationService } from 'src/app/shared/services/toastr.service';
import { Employee } from '../employee.model';
import { EmployeeService } from '../employee.service';

@Component({
  selector: 'app-form',
  templateUrl: './form.component.html',
  styleUrls: ['./form.component.css']
})
export class FormComponent implements OnInit {
  
  @Output() isShow = new EventEmitter<boolean>();

  public employeeForm: FormGroup;
  public action:FormStatus;
  public recruitment : Employee;
  public selectedMulti : string[];


  constructor(
    private fb : FormBuilder,
    private employeeSer : EmployeeService,
    private notify : NotificationService
  ) { }

  ngOnInit(): void {
    this.employeeForm = this.fb.group({
      id:[0,Validators.required],
      name:['',Validators.required],
      email:['',Validators.required],
      address:['',Validators.required],
      phone:['',Validators.required],
      position:['',Validators.required],
      dob:['',Validators.required],
      gender:['',Validators.required],
    });
    this.action = FormStatus.Unknow;
  }

  showForm(){
    if(this.action == FormStatus.Unknow)
      return false;
    return true;
  }
  
  saveFormRecruit(){
    if(this.employeeForm.invalid){
      this.notify.showWarning("Nhập đầy đủ thông tin!","Thông báo");
      return;
    }
    const formValues = this.employeeForm.getRawValue();
    const formData = this.ToFormData(formValues);
    if(this.action == FormStatus.Insert){
      this.employeeSer.insert(formData).subscribe((res:ResponseModel)=>{
        if(res.status == ResponseStatus.success){
          this.notify.showSuccess("Đã thêm thành công","Thông báo");
          this.initialForm();
        }
        else{
          this.notify.showWarning("Thêm thất bại","Thông báo");
        }
      })
    }
    else if(this.action == FormStatus.Update){
      this.employeeSer.update(formData).subscribe((res:ResponseModel)=>{
        if(res.status == ResponseStatus.success){        
          this.action == FormStatus.Insert;
          this.notify.showSuccess("Cập nhật thành công","Thông báo");
        }
        else{
          this.notify.showWarning("Cập nhật thất bại","Thông báo");
        }        
      })
    }
  }
  OpenFormInsert(){
    this.action = FormStatus.Insert;
    this.isShow.emit(false);
    this.initialForm();
  }
  OpenFormUpdate(id:number){
    this.action = FormStatus.Update;
    this.isShow.emit(false);
    this.getItem(id);
  }

  ToFormData(formValue: any) {
    const formData = new FormData();
    for (const key of Object.keys(formValue)) {
      let value = formValue[key];
      if(key === "dob"){
        const month = value.getMonth()+1;
        const day = value.getDate();
        const year = value.getFullYear();
        value = `${month}-${day}-${year}`;
        console.log(value);
      }
      formData.append(key, value);
    }
    return formData;
  }
  onBack(){
    this.action = FormStatus.Unknow;
    this.isShow.emit(true);
  }
  initialForm(){
    this.employeeForm.get('id').setValue(0);
    this.employeeForm.get('name').reset();
    this.employeeForm.get('email').reset();
    this.employeeForm.get('address').reset();
    this.employeeForm.get('phone').reset();
    this.employeeForm.get('gender').reset();
    this.employeeForm.get('position').reset();
    this.employeeForm.get('dob').reset();
  }

  getItem(id:number){
    this.employeeSer.item(id).subscribe((res:ResponseModel)=>{
      if(res.status == ResponseStatus.success){
        this.recruitment = res.result;
        this.setDataForm(this.recruitment);
      }
    })
  }

  setDataForm(data:Employee){
    this.employeeForm.get('id').setValue(data.id);
    this.employeeForm.get('name').setValue(data.name);
    this.employeeForm.get('email').setValue(data.email);
    this.employeeForm.get('address').setValue(data.address);
    this.employeeForm.get('phone').setValue(data.phone);
    this.employeeForm.get('gender').setValue(data.gender);
    this.employeeForm.get('position').setValue(data.position);
    this.employeeForm.get('dob').setValue(data.dob);
  }
}
