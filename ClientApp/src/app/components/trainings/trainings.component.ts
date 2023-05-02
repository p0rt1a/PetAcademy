import { Component, OnInit } from '@angular/core';
import { TrainingsService } from 'src/app/services/trainings.service';

@Component({
  selector: 'app-trainings',
  templateUrl: './trainings.component.html',
  styleUrls: ['./trainings.component.css'],
})
export class TrainingsComponent implements OnInit {
  constructor(private trainingService: TrainingsService) {}

  ngOnInit(): void {
    this.getTrainings();
  }

  getTrainings() {
    this.trainingService.getTrainings().subscribe((response) => {
      console.log(response);
    });
  }
}
