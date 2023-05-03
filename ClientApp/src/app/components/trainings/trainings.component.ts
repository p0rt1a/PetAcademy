import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { CityModel } from 'src/app/models/CityModel';
import { GenreModel } from 'src/app/models/GenreModel';
import { TrainingModel } from 'src/app/models/TrainingModel';
import { CitiesService } from 'src/app/services/cities.service';
import { GenresService } from 'src/app/services/genres.service';
import { TrainingsService } from 'src/app/services/trainings.service';

@Component({
  selector: 'app-trainings',
  templateUrl: './trainings.component.html',
  styleUrls: ['./trainings.component.css'],
})
export class TrainingsComponent implements OnInit {
  trainings: TrainingModel[] = [];
  genres: GenreModel[] = [];
  cities: CityModel[] = [];

  constructor(
    private trainingService: TrainingsService,
    private genreService: GenresService,
    private citiesService: CitiesService,
    private router: Router
  ) {}

  ngOnInit(): void {
    this.getTrainings();
    this.getGenres();
    this.getCities();
  }

  getTrainings() {
    this.trainingService.getTrainings().subscribe((response) => {
      this.trainings = response;
    });
  }

  getGenres() {
    this.genreService.getGenres().subscribe((response) => {
      this.genres = response;
    });
  }

  getCities() {
    this.citiesService.getCities().subscribe((response) => {
      let data: any = response;
      this.cities = data.data;
    });
  }

  getTrainingsByFilter(title: string, city: string, genre: string) {
    this.trainingService
      .getTrainingsByFilter(title, city, genre)
      .subscribe((response) => {
        this.trainings = response;
      });
  }

  selectTraining(id: number) {
    this.trainingService.setSelectedTrainingId(id);
    this.router.navigate(['/training-detail']);
  }
}
