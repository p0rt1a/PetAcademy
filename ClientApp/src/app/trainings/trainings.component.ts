import { Component, OnInit } from '@angular/core';
import { AddTrainingDTO, Category, Training } from '../Models';
import { CategoriesService } from '../_services/categories.service';
import { TrainingsService } from '../_services/trainings.service';

@Component({
  selector: 'trainings',
  templateUrl: './trainings.component.html',
  styleUrls: ['./trainings.component.css'],
})
export class TrainingsComponent implements OnInit {
  trainings?: Training[];

  testTraining: Training = new Training('AAAAA', 'XXXXXX', 'BBBBBB');
  testTrainingDTO: AddTrainingDTO = new AddTrainingDTO(
    this.testTraining,
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

  getTrainingById(id: number) {
    this.trainingService.getTrainingById(id).subscribe((response) => {
      console.log(response);
    });
  }

  addTraining() {
    this.trainingService
      .addTraining(this.testTrainingDTO)
      .subscribe((response) => {
        console.log(response);
      });
  }
}
