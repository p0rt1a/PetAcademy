import { ComponentFixture, TestBed } from '@angular/core/testing';

import { TrainingCategoryComponent } from './training-category.component';

describe('TrainingCategoryComponent', () => {
  let component: TrainingCategoryComponent;
  let fixture: ComponentFixture<TrainingCategoryComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ TrainingCategoryComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(TrainingCategoryComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
