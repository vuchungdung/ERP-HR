import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { FileCvComponent } from './file-cv.component';

describe('FileCvComponent', () => {
  let component: FileCvComponent;
  let fixture: ComponentFixture<FileCvComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ FileCvComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(FileCvComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
