import { Component, OnInit } from '@angular/core';
import { CalendarOptions, EventInput } from '@fullcalendar/angular';
import { ResponseStatus } from 'src/app/core/enums/response-status.enum';
import { ResponseModel } from 'src/app/core/models/response.model';
import { NotificationService } from 'src/app/shared/services/toastr.service';
import { InterviewService } from './interview.service';
declare var $: any;
@Component({
  selector: 'app-interview',
  templateUrl: './interview.component.html',
  styleUrls: ['./interview.component.css']
})
export class InterviewComponent implements OnInit {

  constructor(
    private interviewService : InterviewService,
    private notify : NotificationService,
  ) {
  }

  public dataSource : any;
  

  ngOnInit(): void {  

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
    events : 'https://localhost:44379/api/interview/interviewdate/get-date'
  }

  handleDateClick(arg) {
    alert(arg.dateStr);
  }

  handleEventClick(arg){
    alert(arg.event._def.title);
  }
}
