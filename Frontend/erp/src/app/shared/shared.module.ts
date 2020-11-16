import { NgModule } from '@angular/core';
import { ApiService } from '../core/services/api.service';
import { PaginatorComponent } from './components/paginator/paginator.component';
import { MatPaginatorModule } from '@angular/material/paginator';
@NgModule({
  providers:[
    ApiService
  ],
  declarations: [PaginatorComponent],
  imports:[
    MatPaginatorModule
  ],
  exports:[
    PaginatorComponent
  ]
})
export class SharedModule { }
