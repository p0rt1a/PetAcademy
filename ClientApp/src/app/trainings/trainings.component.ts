import { Component, OnInit } from '@angular/core';
import { AddTrainingDTO, Training } from '../Models';
import { CategoriesService } from '../_services/categories.service';
import { TrainingsService } from '../_services/trainings.service';

@Component({
  selector: 'trainings',
  templateUrl: './trainings.component.html',
  styleUrls: ['./trainings.component.css'],
})
export class TrainingsComponent implements OnInit {
  trainings?: Training[];
  training: AddTrainingDTO = new AddTrainingDTO(
    new Training('Header X', 'Video URL X', 'Description X'),
    [1, 2]
  );

  constructor(
    private trainingService: TrainingsService,
    private categoriesService: CategoriesService
  ) {}

  ngOnInit(): void {
    this.addTraining();
  }

  getTrainings() {
    this.trainingService.getTrainings().subscribe((response) => {
      this.trainings = response;
    });
  }

  addTraining() {
    this.trainingService.addTraining(this.training).subscribe((response) => {
      console.log(response);
    });
  }
}
