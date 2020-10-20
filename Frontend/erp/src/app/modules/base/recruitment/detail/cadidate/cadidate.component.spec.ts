import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { CadidateComponent } from './cadidate.component';

describe('CadidateComponent', () => {
  let component: CadidateComponent;
  let fixture: ComponentFixture<CadidateComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ CadidateComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(CadidateComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
