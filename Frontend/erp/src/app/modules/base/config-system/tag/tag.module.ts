import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { TagComponent } from './tag.component';
import { RouterModule, Routes } from '@angular/router';
import {MatTableModule} from '@angular/material/table';
import { TagService } from './tag.service';


const route : Routes = [
  {
    path:'',
    component: TagComponent,
    pathMatch: 'full'
  }
]

@NgModule({
  declarations: [TagComponent],
  imports: [
    CommonModule,
    RouterModule.forChild(route),
    MatTableModule
  ],
  providers:[
    TagService
  ]
})
export class TagModule { }
