import { Component, EventEmitter, OnInit, Output, Provider } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { MatDialogRef } from '@angular/material/dialog';
import { FormStatus } from 'src/app/core/enums/form-status.enum';
import { ResponseStatus } from 'src/app/core/enums/response-status.enum';
import { ResponseModel } from 'src/app/core/models/response.model';
import { Providers } from '../provider.model';
import { ProviderService } from '../provider.service';

@Component({
  selector: 'app-form',
  templateUrl: './form.component.html',
  styleUrls: ['./form.component.css']
})
export class FormComponent implements OnInit {

  @Output() isReLoadProvider = new EventEmitter<boolean>();

  public readLoad : boolean;
  public providerForm: FormGroup;
  public item: Providers;
  public id:number;
  public action: FormStatus;

  constructor(
    private providerService: ProviderService,
    private fb: FormBuilder,
    private dialogref: MatDialogRef<FormComponent>) { }

  ngOnInit(): void {
    this.providerForm = this.fb.group({
      id:[0,Validators.required],
      name:['',Validators.required],
      link:['',Validators.required]
    });
    this.initialProviderForm();
  }
  
  initialProviderForm(){
    const action = this.dialogref.componentInstance.action;
    if(action == FormStatus.Insert){
      this.providerForm.get('name').reset();
      this.providerForm.get('link').reset();
    }
    else if(action == FormStatus.Update){
      const id = this.dialogref.componentInstance.id;
      this.providerForm.get('id').setValue(id);
      this.getItem(id);
    }
  }

  getItem(id:number){
    this.providerService.item(id).subscribe((res:ResponseModel)=>{
      if(res.status == ResponseStatus.success){
        this.item = res.result;
        this.setDataForm(this.item);
      }
    })
  }

  setDataForm(data: Providers){
    this.providerForm.get('name').setValue(data.name);
    this.providerForm.get('link').setValue(data.link);
  }

  saveForm(){
    const action = this.dialogref.componentInstance.action;
    if(this.providerForm.invalid){
      return;
    }
    if(action == FormStatus.Insert){
      this.providerService.insert(this.providerForm.getRawValue()).subscribe((res:ResponseModel)=>{
        if(res.status == ResponseStatus.success){
          this.isReLoadProvider.emit(true);
        }
        else{
          console.log("Error Insert");
        }
      })
    }
    if(action == FormStatus.Update){
      this.providerService.update(this.providerForm.getRawValue()).subscribe((res:ResponseModel)=>{
        if(res.status == ResponseStatus.success){
          this.isReLoadProvider.emit(true);
        }
        else{
          console.log("Error Update");
        }
      })
    }
  }
}
