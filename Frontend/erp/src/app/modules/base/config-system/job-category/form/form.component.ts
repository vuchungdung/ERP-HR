import { Component, EventEmitter, OnInit, Output } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { MatDialogRef } from '@angular/material/dialog';
import { FormStatus } from 'src/app/core/enums/form-status.enum';
import { ResponseStatus } from 'src/app/core/enums/response-status.enum';
import { ResponseModel } from 'src/app/core/models/response.model';
import { JobCategory } from '../job-category.model';
import { JobCategoryService } from '../job-category.service';

@Component({
  selector: 'app-form',
  templateUrl: './form.component.html',
  styleUrls: ['./form.component.css']
})
export class FormComponent implements OnInit {

  @Output() isReloadJobCategory = new EventEmitter<boolean>();

  public action : FormStatus;
  public formJobC : FormGroup;
  public item: JobCategory;
  public id:number;

  constructor(
    private jobCService: JobCategoryService,
    private fb: FormBuilder,
    private dialogref: MatDialogRef<FormComponent>
  ) { }

  ngOnInit(): void {
    this.formJobC = this.fb.group({
      name:['',Validators.required],
      description:['',Validators.required]
    });
    this.initialJobCategoryForm();
  }

  initialJobCategoryForm(){
    const action = this.dialogref.componentInstance.action;
    if(action == FormStatus.Insert){
      this.formJobC.get('name').reset();
      this.formJobC.get('description').reset();
    }
    else if(action == FormStatus.Update){
      const id = this.dialogref.componentInstance.id;
      this.formJobC.get('id').setValue(id);
      this.getItem(id);
    }
  }

  saveForm(){
    const action = this.dialogref.componentInstance.action;
    if(this.formJobC.invalid){
      return;
    }
    if(action == FormStatus.Insert){
      this.jobCService.insert(this.formJobC.getRawValue()).subscribe((res:ResponseModel)=>{
        if(res.status == ResponseStatus.success){
          this.isReloadJobCategory.emit(true);
        }
        else{
          console.log("Error Insert");
        }
      })
    }
    if(action == FormStatus.Update){
      this.jobCService.update(this.formJobC.getRawValue()).subscribe((res:ResponseModel)=>{
        if(res.status == ResponseStatus.success){
          this.isReloadJobCategory.emit(true);
        }
        else{
          console.log("Error Update");
        }
      })
    }
  }

  getItem(id:number){
    this.jobCService.item(id).subscribe((res:ResponseModel)=>{
      if(res.status == ResponseStatus.success){
        this.item = res.result;
        this.setDataToForm(this.item);
      }
    })
  }

  private setDataToForm(data: JobCategory) {
    this.formJobC.get('name').setValue(data.name);
    this.formJobC.get('description').setValue(data.description);
  }
}
