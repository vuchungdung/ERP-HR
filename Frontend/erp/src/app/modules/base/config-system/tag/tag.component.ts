import { Component, OnInit } from '@angular/core';
import { Tag } from './tag.model';

@Component({
  selector: 'app-tag',
  templateUrl: './tag.component.html',
  styleUrls: ['./tag.component.css']
})


export class TagComponent implements OnInit {

  constructor() { }

  ngOnInit(): void {

  }

  ELEMENT_DATA: Tag[] = [
    {name: 'Chưa có kinh nghiệm', content: 'Đang là thực tập sinh, chưa có kinh nghiệm', color:'label label-success'},
    {name: 'Chuyên môn tốt', content: 'Đã đi làm nhiều năm, có nhiều kinh nghiệm làm việc', color:'label label-danger'},
    {name: 'Có kinh nghiệm', content: 'Đã có kinh nghiệm nhưng chưa lâu', color:'label label-default'},
    {name: 'Hồ sơ tốt', content: 'Hồ sơ xin việc có nhiều công nghệ đáng chú ý', color:'label label-primary'},
    {name: 'Giao tiếp tốt', content: 'Ứng viên có tác phong tốt, giao tiếp lưu loát', color:'label label-warning'},
  ];

  displayedColumns: string[] = ['name', 'content','options'];
  dataSource = this.ELEMENT_DATA;
}
