import { Component, EventEmitter, OnInit, Output } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { FormStatus } from 'src/app/core/enums/form-status.enum';
import { ResponseStatus } from 'src/app/core/enums/response-status.enum';
import { ResponseModel } from 'src/app/core/models/response.model';
import { NotificationService } from 'src/app/shared/services/toastr.service';
import { Skill } from '../skill.model';
import { SkillService } from '../skill.service';

@Component({
  selector: 'app-form',
  templateUrl: './form.component.html',
  styleUrls: ['./form.component.css']
})
export class FormComponent implements OnInit {

  @Output() isReLoadTable = new EventEmitter<boolean>();

  public action : FormStatus
  public skillForm : FormGroup;
  public id : number;
  public item : Skill;
  public listOps : any[] = [];
  public status : boolean;
  constructor(
    private fb: FormBuilder,
    private skillService: SkillService,
    private notify: NotificationService
  ) { }

  ngOnInit(): void {
    this.skillForm = this.fb.group({
      id:[0,Validators.required],
      name:['',Validators.required]
    });
  }
  
  showForm(){
    return this.status;
  }

  saveForm(){
    if(this.skillForm.invalid){
      return;
    }
    if(this.action == FormStatus.Insert){
      this.skillService.insert(this.skillForm.getRawValue()).subscribe((res:ResponseModel)=>{
        if(res.status == ResponseStatus.success){
          this.isReLoadTable.emit(true);
          this.initialForm();
          this.notify.showSuccess("Thêm mới thành công!","Thông báo");
        }
        else{
          this.notify.showSuccess("Thêm mới thất bại!","Thông báo");
        }
      })
    }
    else if(this.action == FormStatus.Update){
      this.skillService.update(this.skillForm.getRawValue()).subscribe((res:ResponseModel)=>{
        if(res.status == ResponseStatus.success){
          this.isReLoadTable.emit(true);
          this.notify.showSuccess("Cập nhật thành công!","Thông báo");
        }
        else{
          this.notify.showSuccess("Cập nhật thất bại!","Thông báo");
        }
      })
    }
  }


  openInsertForm(){
    this.status = true;
    this.action = FormStatus.Insert;
    this.isReLoadTable.emit(true);
    this.initialForm();
  }

  openUpdateForm(id:number){
    this.status = true;
    this.action = FormStatus.Update;
    this.isReLoadTable.emit(true);
    this.getItem(id);
  }

  onBack(){
    this.status = false;
    this.isReLoadTable.emit(true);
    this.showForm();
  }

  initialForm(){
    this.skillForm.get('name').reset();
    this.skillForm.get('id').setValue(0);
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
    this.skillForm.get('id').setValue(data.id);
    this.skillForm.get('name').setValue(data.name);
  }

}
