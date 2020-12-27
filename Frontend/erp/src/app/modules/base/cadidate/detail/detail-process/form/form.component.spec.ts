import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { FormComponentProcess } from './form.component';

describe('FormComponent', () => {
  let component: FormComponentProcess;
  let fixture: ComponentFixture<FormComponentProcess>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ FormComponentProcess ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(FormComponentProcess);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
