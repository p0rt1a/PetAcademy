import { Component, Input, OnInit } from '@angular/core';
import { Training } from '../Models';
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
  }

  ngDoCheck() {
    if (this.category == 0) {
      this.getTrainings();
      this.category = undefined;
    }
    if (this.category != undefined) {
      this.getTrainingsByCategoryId(this.category);
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
