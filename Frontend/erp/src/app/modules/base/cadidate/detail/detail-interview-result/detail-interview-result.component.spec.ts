import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { DetailInterviewResultComponent } from './detail-interview-result.component';

describe('DetailInterviewResultComponent', () => {
  let component: DetailInterviewResultComponent;
  let fixture: ComponentFixture<DetailInterviewResultComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ DetailInterviewResultComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(DetailInterviewResultComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
