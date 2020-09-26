import { Component, OnInit, Provider } from '@angular/core';
import { FormBuilder, FormGroup } from '@angular/forms';
import { MatDialogRef } from '@angular/material/dialog';
import { FormStatus } from 'src/app/core/enums/form-status.enum';
import { ProviderService } from '../provider.service';

@Component({
  selector: 'app-form',
  templateUrl: './form.component.html',
  styleUrls: ['./form.component.css']
})
export class FormComponent implements OnInit {

  readLoad : boolean;
  providerForm: FormGroup;
  item: Provider;
  id:number;
  action: FormStatus;

  constructor(
    private providerService: ProviderService,
    private fb: FormBuilder,
    private dialogref: MatDialogRef<FormComponent>) { }

  ngOnInit(): void {

  }
  
}
