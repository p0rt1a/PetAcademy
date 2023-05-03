import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { TrainingDetailModel } from 'src/app/models/TrainingDetailModel';
import { TrainingsService } from 'src/app/services/trainings.service';

@Component({
  selector: 'app-training-detail',
  templateUrl: './training-detail.component.html',
  styleUrls: ['./training-detail.component.css'],
})
export class TrainingDetailComponent implements OnInit {
  selectedTrainingId: number = 0;
  training: TrainingDetailModel = new TrainingDetailModel(
    '',
    '',
    '',
    '',
    '',
    0,
    '',
    ''
  );

  constructor(
    private trainingsService: TrainingsService,
    private router: Router
  ) {}

  ngOnInit(): void {
    this.trainingsService.selectedTrainingId.subscribe((response) => {
      this.selectedTrainingId = response;
    });

    this.getTrainingDetail();
  }

  getTrainingDetail() {
    this.trainingsService
      .getTrainingDetail(this.selectedTrainingId)
      .subscribe((response) => {
        this.training = response;
      });
  }

  createEnrollment() {
    this.router.navigate(['/create-enrollment']);
  }
}
