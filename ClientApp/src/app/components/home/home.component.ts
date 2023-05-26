import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { GenreModel } from 'src/app/models/GenreModel';
import { TrainingModel } from 'src/app/models/TrainingModel';
import { UserViewModel } from 'src/app/models/UserViewModel';
import { GenresService } from 'src/app/services/genres.service';
import { TrainingsService } from 'src/app/services/trainings.service';
import { UsersService } from 'src/app/services/users.service';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.css'],
})
export class HomeComponent implements OnInit {
  genres: GenreModel[] = [];
  trainings: TrainingModel[] = [];
  runningOutTrainings: TrainingModel[] = [];
  fullTrainings: TrainingModel[] = [];
  users: UserViewModel[] = [];

  constructor(
    private trainingsService: TrainingsService,
    private genresService: GenresService,
    private router: Router,
    private usersService: UsersService
  ) {}

  ngOnInit(): void {
    this.trainingsService.getTrainings().subscribe((response) => {
      this.trainings = response;
    });

    this.usersService.getUsers().subscribe((response) => {
      this.users = response;
    });

    this.genresService.getGenres().subscribe((response) => {
      this.genres = response;
    });

    this.trainingsService.getRunningOutTrainings().subscribe((response) => {
      this.runningOutTrainings = response;
    });

    this.trainingsService.getFullTrainings().subscribe((response) => {
      this.fullTrainings = response;
    });
  }

  selectTraining(id: number) {
    this.trainingsService.setSelectedTrainingId(id);
    this.router.navigate(['/training-detail']);
  }
}
