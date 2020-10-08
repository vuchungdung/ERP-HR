import { Component, OnInit, Output } from '@angular/core';
import { FormBuilder, FormGroup } from '@angular/forms';
import { MatDialogRef } from '@angular/material/dialog';
import { EventEmitter } from 'protractor';
import { FormStatus } from 'src/app/core/enums/form-status.enum';
import { JobCategory } from '../job-category.model';
import { JobCategoryService } from '../job-category.service';

@Component({
  selector: 'app-form',
  templateUrl: './form.component.html',
  styleUrls: ['./form.component.css']
})
export class FormComponent implements OnInit {

  @Output() isReloadJobCategory = new EventEmitter();

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
  }

  initialJobCategoryForm(){
    const action = this.dialogref.componentInstance.action;
    if(action == FormStatus.Insert){
      this.formJobC.get('').reset();
      this.formJobC.get('').reset();
      this.formJobC.get('').reset();
    }
  }

  setDataForm(){

  }

  getItem(id:number){

  }

  saveForm(){
    
  }
}
