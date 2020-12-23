import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { DetailEducationComponent } from './detail-education.component';

describe('DetailEducationComponent', () => {
  let component: DetailEducationComponent;
  let fixture: ComponentFixture<DetailEducationComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ DetailEducationComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(DetailEducationComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
