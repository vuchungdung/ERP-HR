import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { SkillComponent } from './skill.component';
import { RouterModule, Routes } from '@angular/router';

const routes: Routes = [
  {
    path:'',
    component : SkillComponent,
    pathMatch:'full'
  }
]
@NgModule({
  declarations: [SkillComponent],
  imports: [
    CommonModule,
    RouterModule.forChild(routes)
  ]
})
export class SkillModule { }
