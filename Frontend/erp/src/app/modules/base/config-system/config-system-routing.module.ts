import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { ConfigSystemComponent } from './config-system.component';

const routes: Routes = [
  {
    path:'',
    component: ConfigSystemComponent,
    children:[
      {
        path: 'file',
        loadChildren: () => import('../config-system/file-cv/file-cv.module').then(m => m.FileCvModule)
      },
      {
        path: 'jobcategory',
        loadChildren: () => import('../config-system/job-category/job-category.module').then(m => m.JobCategoryModule)
      },
      {
        path: 'process',
        loadChildren: () => import('../config-system/process/process.module').then(m => m.ProcessModule)
      },
      {
        path: 'skill',
        loadChildren: () => import('../config-system/skill/skill.module').then(m => m.SkillModule)
      },
      {
        path: 'tag',
        loadChildren: () => import('../config-system/tag/tag.module').then(m => m.TagModule)
      },
      {
        path: 'provider',
        loadChildren: () => import('../config-system/provider/provider.module').then(m => m.ProviderModule)
      }
    ]
  }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class ConfigSystemRoutingModule{}