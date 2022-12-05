import { Component, Input, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { Training } from '../Models';
import { TrainingsService } from '../_services/trainings.service';

@Component({
  selector: 'trainings',
  templateUrl: './trainings.component.html',
  styleUrls: ['./trainings.component.css'],
})
export class TrainingsComponent implements OnInit {
  category?: number;
  trainings?: Training[];
  url: string = '/home';

  constructor(
    private trainingService: TrainingsService,
    private router: Router
  ) {}

  ngOnInit(): void {
    this.getTrainings();

    this.url = this.router.url;
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

  getSelectedCategory(name: number) {
    this.category = name;
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
