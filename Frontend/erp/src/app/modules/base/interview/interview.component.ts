import { Component, OnInit } from '@angular/core';
import { CalendarOptions, EventInput } from '@fullcalendar/angular';

@Component({
  selector: 'app-interview',
  templateUrl: './interview.component.html',
  styleUrls: ['./interview.component.css']
})
export class InterviewComponent implements OnInit {

  constructor() {   
  }

  ngOnInit(): void {   
  }

  public dataSource : EventInput[] = this.getList();

  getList(){
    return [
      { title: 'Phỏng vấn ứng viên Vũ Chung Dũng', date: '2020-12-10' },
      { title: 'Phỏng vấn ứng viên Nguyễn Thị Hòa', date: '2020-12-10' }
    ];
  }

  calendarOptions: CalendarOptions = {
    headerToolbar: {
      left: 'prev,next today',
      center: 'title',
      right: 'dayGridMonth,timeGridWeek,timeGridDay,listWeek'
    },
    initialView: 'dayGridMonth',
    dateClick : this.handleDateClick.bind(this),
    eventClick : this.handleEventClick.bind(this),
    events : this.dataSource
  }

  handleDateClick(arg) {
    alert(arg.dateStr);
  }

  handleEventClick(arg){
    alert(arg.event._def.title);
  }
}
