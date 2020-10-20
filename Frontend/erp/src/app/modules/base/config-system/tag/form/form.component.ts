import { Component, EmbeddedViewRef, EventEmitter, Inject, OnInit, Output } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { MatDialogRef, MAT_DIALOG_DATA } from '@angular/material/dialog';
import { FormStatus } from 'src/app/core/enums/form-status.enum';
import { ResponseStatus } from 'src/app/core/enums/response-status.enum';
import { ResponseModel } from 'src/app/core/models/response.model';
import { Tag } from '../tag.model';
import { TagService } from '../tag.service';

@Component({
  selector: 'app-form',
  templateUrl: './form.component.html',
  styleUrls: ['./form.component.css']
})
export class FormComponent implements OnInit {
  
  @Output() isReLoadTag = new EventEmitter<boolean>();
  
  public tagForm: FormGroup;
  public item: Tag;
  public id: number;
  public action: FormStatus;

  constructor(
    private fb:FormBuilder,
    private tagService: TagService,
    private dialogRef: MatDialogRef<FormComponent>) { }

  ngOnInit(): void {
    this.tagForm = this.fb.group({
      id:[0,Validators.required],
      name:['',Validators.required],
      content:['',Validators.required],
      color:['',Validators.required]
    })
    this.initTagForm();
  }

  getColorLabel($event){
    let _class = $event.toElement.className;
    var arr = _class.split(' ');
    this.tagForm.get('color').setValue(arr[0]);
  }
  
  initTagForm(){
    const action = this.dialogRef.componentInstance.action;
    if(action == FormStatus.Insert){
      this.tagForm.get('name').reset();
      this.tagForm.get('content').reset();
      this.tagForm.get('color').reset();
    }
    else if(action == FormStatus.Update){
      const id = this.dialogRef.componentInstance.id;
      this.tagForm.get('id').setValue(id);
      this.getItem(id);
    }
  }

  saveForm(){
    const action = this.dialogRef.componentInstance.action;
    if(this.tagForm.invalid){
      return;
    }
    if(action == FormStatus.Insert){
      this.tagService.insert(this.tagForm.getRawValue()).subscribe((res: ResponseModel)=>{
        if(res.status == ResponseStatus.success){
          this.isReLoadTag.emit(true);
        }
        else{
          console.log("Error Insert");
        }
      });
    }
    else if(action == FormStatus.Update){
      this.tagService.update(this.tagForm.getRawValue()).subscribe((res:ResponseModel)=>{
        if(res.status == ResponseStatus.success){
          this.isReLoadTag.emit(true);
        }
        else{
          console.log("Error Update");
        }
      });
    }    
  }
  getItem(id:number){
    this.tagService.item(id).subscribe((res:ResponseModel)=>{
      if(res.status == ResponseStatus.success){
        this.item = res.result;
        this.setDataToForm(this.item);
      }
    })
  }

  private setDataToForm(data: Tag) {
    this.tagForm.get('name').setValue(data.name);
    this.tagForm.get('content').setValue(data.content);
    this.tagForm.get('color').setValue(data.color);
  }
}
