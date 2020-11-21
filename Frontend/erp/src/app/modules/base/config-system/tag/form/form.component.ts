import { Component, EmbeddedViewRef, EventEmitter, Inject, OnInit, Output } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { MatDialogRef, MAT_DIALOG_DATA } from '@angular/material/dialog';
import { FormStatus } from 'src/app/core/enums/form-status.enum';
import { ResponseStatus } from 'src/app/core/enums/response-status.enum';
import { ResponseModel } from 'src/app/core/models/response.model';
import { NotificationService } from 'src/app/shared/services/toastr.service';
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
  public action: FormStatus;
  public status : boolean = false;

  constructor(
    private fb:FormBuilder,
    private tagService: TagService,
    private notify: NotificationService) { }

  ngOnInit(): void {
    this.tagForm = this.fb.group({
      id:[0,Validators.required],
      name:['',Validators.required],
      content:['',Validators.required],
      color:['bg-success',Validators.required]
    })
    this.initTagForm();
  }
  
  initTagForm(){
    this.tagForm.get('content').reset();
    this.tagForm.get('name').reset();
  }

  openFormInsert(){
    this.action = FormStatus.Insert;
    this.status = true;
    this.initTagForm();
  }

  openFormUpdate(id : number){
    this.action = FormStatus.Update;
    this.status = true;
    this.initTagForm();
    this.getItem(id);
  }

  showForm(){
    return this.status;
  }

  onBack(){
    this.status = false;
  }

  saveForm(){
    if(this.tagForm.invalid){
      return;
    }
    if(this.action == FormStatus.Insert){
      this.tagService.insert(this.tagForm.getRawValue()).subscribe((res: ResponseModel)=>{
        if(res.status == ResponseStatus.success){
          this.initTagForm();
          this.isReLoadTag.emit(true);
          this.notify.showSuccess("Thêm mới thành công!","Thông báo");
        }
        else{
          this.notify.showWarning("Thêm mới thất bại!","Thông báo");
        }
      });
    }
    else if(this.action == FormStatus.Update){
      this.tagService.update(this.tagForm.getRawValue()).subscribe((res:ResponseModel)=>{
        if(res.status == ResponseStatus.success){
          this.isReLoadTag.emit(true);
          this.notify.showSuccess("Cập nhật thành công!","Thông báo");
        }
        else{
          this.notify.showWarning("Cập nhật thất bại!","Thông báo");
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
  }
}
