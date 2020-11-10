import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { PlanRecruitComponent } from './plan-recruit.component';

describe('PlanRecruitComponent', () => {
  let component: PlanRecruitComponent;
  let fixture: ComponentFixture<PlanRecruitComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ PlanRecruitComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(PlanRecruitComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
