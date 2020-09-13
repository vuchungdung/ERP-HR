import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { TagComponent } from './tag.component';
import { RouterModule, Routes } from '@angular/router';
import {MatTableModule} from '@angular/material/table';
import { TagService } from './tag.service';
import {MatIconModule} from '@angular/material/icon';
import {MatButtonModule} from '@angular/material/button';
import { FormComponent } from './form/form.component';
import {MatDialogModule} from '@angular/material/dialog';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';


const route : Routes = [
  {
    path:'',
    component: TagComponent,
    pathMatch: 'full'
  }
]

@NgModule({
  declarations: [TagComponent, FormComponent],
  imports: [
    CommonModule,
    RouterModule.forChild(route),
    MatTableModule,
    MatIconModule,
    MatButtonModule,
    MatDialogModule,
    FormsModule,
    ReactiveFormsModule
  ],
  providers:[
    TagService
  ]
})
export class TagModule { }
