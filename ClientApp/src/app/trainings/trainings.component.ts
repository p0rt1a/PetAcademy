import { Component, EventEmitter, Input, OnInit } from '@angular/core';
import { Training } from '../Models';
import { CategoryTrainingService } from '../_services/category-training.service';
import { TrainingsService } from '../_services/trainings.service';

@Component({
  selector: 'trainings',
  templateUrl: './trainings.component.html',
  styleUrls: ['./trainings.component.css'],
})
export class TrainingsComponent implements OnInit {
  @Input() category?: number;
  trainings?: Training[];

  constructor(private trainingService: TrainingsService) {}

  ngOnInit(): void {
    this.getTrainings();
    console.log(this.category);
    console.log('On Init worked');
  }

  ngDoCheck() {
    if (this.category == 0) {
      this.getTrainings();
      this.category = undefined;
    }
    if (this.category != undefined) {
      this.getTrainingsByCategoryId(this.category);
      console.log('Do Check method worked');
      this.category = undefined;
    }
  }

  getTrainings() {
    this.trainingService.getTrainings().subscribe(
      (response) => {
        this.trainings = response;
      },
      (error) => {
        console.log('Error: ' + error);
      }
    );
  }

  getTrainingsByCategoryId(id: number) {
    this.trainingService.getTrainingsByCategoryId(id).subscribe((response) => {
      this.trainings = response;
    });
  }
}
