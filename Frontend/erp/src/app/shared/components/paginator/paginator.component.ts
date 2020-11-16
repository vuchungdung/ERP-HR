import { EventEmitter } from '@angular/core';
import { Input } from '@angular/core';
import { Output } from '@angular/core';
import { Component, OnInit } from '@angular/core';
import { PageEvent } from '@angular/material/paginator';
import { PagingModel } from 'src/app/core/models/paging.model';

@Component({
  selector: 'app-paginator',
  templateUrl: './paginator.component.html',
  styleUrls: ['./paginator.component.css']
})
export class PaginatorComponent implements OnInit {

  @Input() paging: PagingModel;
  @Output() pageEventChange = new EventEmitter<PageEvent>();

  constructor() {
  }

  ngOnInit(): void {
  }

  onPageChange(event: PageEvent) {
    this.pageEventChange.emit(event);
  }

}
