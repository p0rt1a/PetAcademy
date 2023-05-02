import { Component, OnInit } from '@angular/core';
import { TrainingModel } from 'src/app/models/TrainingModel';
import { TrainingsService } from 'src/app/services/trainings.service';

@Component({
  selector: 'app-trainings',
  templateUrl: './trainings.component.html',
  styleUrls: ['./trainings.component.css'],
})
export class TrainingsComponent implements OnInit {
  trainings: TrainingModel[] = [];

  constructor(private trainingService: TrainingsService) {}

  ngOnInit(): void {
    this.getTrainings();
  }

  getTrainings() {
    this.trainingService.getTrainings().subscribe((response) => {
      this.trainings = response;
      console.log(response);
    });
  }
}
