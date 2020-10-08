import { Component, OnInit } from '@angular/core';
import { MatDialog } from '@angular/material/dialog';
import { ToastrService } from 'ngx-toastr';
import { PagingModel } from 'src/app/core/models/paging.model';
import { ProviderService } from './provider.service';

@Component({
  selector: 'app-provider',
  templateUrl: './provider.component.html',
  styleUrls: ['./provider.component.css']
})
export class ProviderComponent implements OnInit {

  public paging = new PagingModel();
  public searchText = '';
  public dataSource: any;
  public displayedColumns: string[] = ['name', 'link','options'];

  constructor(
    private providerService: ProviderService,
    private dialog: MatDialog,
    private toarts: ToastrService
  ) { }

  ngOnInit(): void {
  }

  insertProvider(){
    
  }

  updateProvider(id:number){

  }

  deleteProvider(){

  }

  getList(){

  }
}
