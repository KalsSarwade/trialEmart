import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { DisplayAllProductsOfCategoryComponent } from './display-all-products-of-category.component';

describe('DisplayAllProductsOfCategoryComponent', () => {
  let component: DisplayAllProductsOfCategoryComponent;
  let fixture: ComponentFixture<DisplayAllProductsOfCategoryComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ DisplayAllProductsOfCategoryComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(DisplayAllProductsOfCategoryComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
