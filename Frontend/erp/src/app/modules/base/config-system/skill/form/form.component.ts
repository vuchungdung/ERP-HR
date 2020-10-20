import { Component, EventEmitter, OnInit, Output } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { MatDialogRef } from '@angular/material/dialog';
import { FormStatus } from 'src/app/core/enums/form-status.enum';
import { ResponseStatus } from 'src/app/core/enums/response-status.enum';
import { ResponseModel } from 'src/app/core/models/response.model';
import { Skill } from '../skill.model';
import { SkillService } from '../skill.service';

@Component({
  selector: 'app-form',
  templateUrl: './form.component.html',
  styleUrls: ['./form.component.css']
})
export class FormComponent implements OnInit {

  @Output() isReLoadSkill = new EventEmitter<boolean>();

  public action : FormStatus
  public skillForm : FormGroup;
  public id : number;
  public item : Skill;
  public listOps : any[] = [];
  constructor(
    private fb: FormBuilder,
    private skillService: SkillService,
    private dialogRef : MatDialogRef<FormComponent>
  ) { }

  ngOnInit(): void {
    this.skillForm = this.fb.group({
      name:['',Validators.required]
    })
    this.initialSkillForm();
  }

  saveForm(){
    const action = this.dialogRef.componentInstance.action;
    if(this.skillForm.invalid){
      return;
    }
    if(action == FormStatus.Insert){
      this.skillService.insert(this.skillForm.getRawValue()).subscribe((res:ResponseModel)=>{
        if(res.status == ResponseStatus.success){
          this.isReLoadSkill.emit(true);
        }
        else{
          console.log('Error Insert');
        }
      })
    }
  }

  initialSkillForm(){
    const action = this.dialogRef.componentInstance.action;
    if(action == FormStatus.Insert){
      this.skillForm.get('name').reset();
    }
    else if(action == FormStatus.Update){
      const id = this.dialogRef.componentInstance.id;
      this.getItem(id);
    }
  }

  getItem(id:number){
    this.skillService.item(id).subscribe((res:ResponseModel)=>{
      if(res.status == ResponseStatus.success){
        this.item = res.result;
        this.setDataForm(this.item);
      }
    })
  }

  setDataForm(data:Skill){
    this.skillForm.get('name').setValue(data.name);
  }

}
