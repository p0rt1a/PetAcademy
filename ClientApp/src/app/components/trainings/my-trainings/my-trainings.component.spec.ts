import { ComponentFixture, TestBed } from '@angular/core/testing';

import { MyTrainingsComponent } from './my-trainings.component';

describe('MyTrainingsComponent', () => {
  let component: MyTrainingsComponent;
  let fixture: ComponentFixture<MyTrainingsComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ MyTrainingsComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(MyTrainingsComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
