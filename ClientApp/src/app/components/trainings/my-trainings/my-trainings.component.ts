import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { TrainingModel } from 'src/app/models/TrainingModel';
import { AuthService } from 'src/app/services/auth.service';
import { TrainingsService } from 'src/app/services/trainings.service';
import { UsersService } from 'src/app/services/users.service';

@Component({
  selector: 'app-my-trainings',
  templateUrl: './my-trainings.component.html',
  styleUrls: ['./my-trainings.component.css'],
})
export class MyTrainingsComponent implements OnInit {
  trainings: TrainingModel[] = [];

  constructor(
    private usersService: UsersService,
    private authService: AuthService,
    private trainingsService: TrainingsService,
    private router: Router
  ) {}

  ngOnInit(): void {
    this.usersService
      .getUserTrainings(this.authService.getUserId())
      .subscribe((response) => {
        console.log(response);
        this.trainings = response;
      });
  }

  updateTrainings(id: any) {
    this.trainingsService.setSelectedTrainingId(id);
    this.router.navigate(['/update-training']);
  }
}
