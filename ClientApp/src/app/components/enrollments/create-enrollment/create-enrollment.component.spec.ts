import { ComponentFixture, TestBed } from '@angular/core/testing';

import { CreateEnrollmentComponent } from './create-enrollment.component';

describe('CreateEnrollmentComponent', () => {
  let component: CreateEnrollmentComponent;
  let fixture: ComponentFixture<CreateEnrollmentComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ CreateEnrollmentComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(CreateEnrollmentComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
