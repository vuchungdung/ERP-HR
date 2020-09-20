import { Component, EmbeddedViewRef, EventEmitter, OnInit, Output } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { emitWarning } from 'process';
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
  
  @Output() reLoadData = new EventEmitter<boolean>();
  tagForm: FormGroup;

  constructor(
    private fb:FormBuilder,
    private tagService: TagService) { }

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
    if(this.tagForm.invalid){
      return;
    }
    this.tagService.insert(this.tagForm.getRawValue()).subscribe((res: ResponseModel)=>{
      if(res.status == ResponseStatus.success){
        console.log("success");
        this.reLoadData.emit(true);
      }
      else{
        console.log("Error");
      }
    })
  }
  
}
