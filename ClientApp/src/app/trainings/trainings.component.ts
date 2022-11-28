import { Component, OnInit } from '@angular/core';
import { Training } from '../Models';
import { TrainingsService } from '../_services/trainings.service';

@Component({
  selector: 'trainings',
  templateUrl: './trainings.component.html',
  styleUrls: ['./trainings.component.css'],
})
export class TrainingsComponent implements OnInit {
  trainings?: Training[];

  constructor(private trainingService: TrainingsService) {}

  ngOnInit(): void {
    this.getTrainings();
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
}
