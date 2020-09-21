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
  
  @Output() isReloadData = new EventEmitter<boolean>();
  reLoadData : boolean;
  tagForm: FormGroup;
  item: Tag;
  id: number;
  action: FormStatus;

  constructor(
    private fb:FormBuilder,
    private tagService: TagService,
    private dialogRef: MatDialogRef<FormComponent>) { }

  ngOnInit(): void {
    this.tagForm = this.fb.group({
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
    this.tagForm.get('name').reset();
    this.tagForm.get('content').reset();
    this.tagForm.get('color').reset();
  }

  saveForm(){
    const id = this.dialogRef.componentInstance.id;
    const action = this.dialogRef.componentInstance.action;
    // if(this.tagForm.invalid){
    //   return;
    // }
    // this.tagService.insert(this.tagForm.getRawValue()).subscribe((res: ResponseModel)=>{
    //   if(res.status == ResponseStatus.success){
    //     this.isReloadData.emit(true);
    //   }
    //   else{
    //     console.log("Error");
    //   }
    // })
  }
  updateForm(){
    if(this.tagForm.invalid){
      return;
    }
    this.tagService.update(this.tagForm.getRawValue()).subscribe((res:ResponseModel)=>{
      if(res.status == ResponseStatus.success){
        this.isReloadData.emit(true);
      }
    })
  }

  onUpdateForm(id:number){
    console.log(id);
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
