import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { DetailApplyHistoryComponent } from './detail-apply-history.component';

describe('DetailApplyHistoryComponent', () => {
  let component: DetailApplyHistoryComponent;
  let fixture: ComponentFixture<DetailApplyHistoryComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ DetailApplyHistoryComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(DetailApplyHistoryComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
