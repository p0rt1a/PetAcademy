import { Component, OnInit } from '@angular/core';
import { CreateEnrollmentModel } from 'src/app/models/CreateEnrollmentModel';
import { EnrollmentsService } from 'src/app/services/enrollments.service';
import { TrainingsService } from 'src/app/services/trainings.service';

@Component({
  selector: 'app-create-enrollment',
  templateUrl: './create-enrollment.component.html',
  styleUrls: ['./create-enrollment.component.css'],
})
export class CreateEnrollmentComponent implements OnInit {
  constructor(
    private trainingsService: TrainingsService,
    private enrollmentsService: EnrollmentsService
  ) {}

  ngOnInit(): void {}

  createEnrollment(petId: number) {
    let model = new CreateEnrollmentModel(petId, 0);
    this.trainingsService.selectedTrainingId.subscribe((response) => {
      model.trainingId = response;
    });

    this.enrollmentsService.createEnrollment(model);
  }
}
