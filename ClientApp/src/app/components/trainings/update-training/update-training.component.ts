import { Component, OnInit } from '@angular/core';
import { TrainingDetailModel } from 'src/app/models/TrainingDetailModel';
import { UpdateTrainingModel } from 'src/app/models/UpdateTrainingModel';
import { TrainingsService } from 'src/app/services/trainings.service';

@Component({
  selector: 'app-update-training',
  templateUrl: './update-training.component.html',
  styleUrls: ['./update-training.component.css'],
})
export class UpdateTrainingComponent implements OnInit {
  training: TrainingDetailModel = new TrainingDetailModel(
    '',
    '',
    '',
    '',
    '',
    0,
    '',
    '',
    0
  );
  selectedTrainingId: number = 0;
  updateTrainingModel: UpdateTrainingModel = new UpdateTrainingModel('', 0, 0);

  constructor(private trainingsService: TrainingsService) {}

  ngOnInit(): void {
    this.trainingsService.selectedTrainingId.subscribe(
      (response) => (this.selectedTrainingId = response)
    );

    this.trainingsService
      .getTrainingDetail(this.selectedTrainingId)
      .subscribe((response) => {
        this.training = response;
      });
  }

  updateTraining() {}
}
