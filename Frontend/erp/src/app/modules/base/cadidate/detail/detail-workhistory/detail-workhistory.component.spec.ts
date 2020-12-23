import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { DetailWorkhistoryComponent } from './detail-workhistory.component';

describe('DetailWorkhistoryComponent', () => {
  let component: DetailWorkhistoryComponent;
  let fixture: ComponentFixture<DetailWorkhistoryComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ DetailWorkhistoryComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(DetailWorkhistoryComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
