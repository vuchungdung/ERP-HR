import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { SkillComponent } from './skill.component';
import { RouterModule, Routes } from '@angular/router';
import { FormComponent } from './form/form.component';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { MatButtonModule } from '@angular/material/button';
import { MatDialogModule } from '@angular/material/dialog';
import { MatIconModule } from '@angular/material/icon';
import { MatTableModule } from '@angular/material/table';
import { ApiService } from 'src/app/core/services/api.service';
import { SkillService } from './skill.service';

const routes: Routes = [
  {
    path:'',
    component : SkillComponent,
    pathMatch:'full'
  }
]
@NgModule({
  declarations: [SkillComponent, FormComponent],
  imports: [
    CommonModule,
    RouterModule.forChild(routes),
    MatTableModule,
    MatIconModule,
    MatButtonModule,
    MatDialogModule,
    FormsModule,
    ReactiveFormsModule
  ],
  providers:[
    SkillService
  ]
})
export class SkillModule { }
