import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { DisplayCategoryTableComponent } from './display-category-table.component';

describe('DisplayCategoryTableComponent', () => {
  let component: DisplayCategoryTableComponent;
  let fixture: ComponentFixture<DisplayCategoryTableComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ DisplayCategoryTableComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(DisplayCategoryTableComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
