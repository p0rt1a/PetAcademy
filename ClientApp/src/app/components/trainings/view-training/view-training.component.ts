import { Component, OnInit } from '@angular/core';
import { TrainingDetailModel } from 'src/app/models/TrainingDetailModel';
import { TrainingPetViewModel } from 'src/app/models/TrainingPetViewModel';
import { TrainingsService } from 'src/app/services/trainings.service';

@Component({
  selector: 'app-view-training',
  templateUrl: './view-training.component.html',
  styleUrls: ['./view-training.component.css'],
})
export class ViewTrainingComponent implements OnInit {
  selectedTrainingId: number = 0;
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
  pets: TrainingPetViewModel[] = [];

  constructor(private trainingsService: TrainingsService) {}

  ngOnInit(): void {
    this.trainingsService.selectedTrainingId.subscribe((res) => {
      this.selectedTrainingId = res;
    });

    this.trainingsService
      .getTrainingPets(this.selectedTrainingId)
      .subscribe((response) => {
        this.pets = response;
      });

    this.trainingsService
      .getTrainingDetail(this.selectedTrainingId)
      .subscribe((response) => {
        this.training = response;
      });
  }
}
