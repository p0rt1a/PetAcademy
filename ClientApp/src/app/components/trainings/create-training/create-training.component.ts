import { Component, OnInit } from '@angular/core';
import {
  FormBuilder,
  FormControl,
  FormGroup,
  Validators,
} from '@angular/forms';
import { CityModel } from 'src/app/models/CityModel';
import { CreateCommentModel } from 'src/app/models/CreateCommentModel';
import { CreateTrainingModel } from 'src/app/models/CreateTrainingModel';
import { GenreModel } from 'src/app/models/GenreModel';
import { AuthService } from 'src/app/services/auth.service';
import { CitiesService } from 'src/app/services/cities.service';
import { GenresService } from 'src/app/services/genres.service';
import { TrainingsService } from 'src/app/services/trainings.service';

@Component({
  selector: 'app-create-training',
  templateUrl: './create-training.component.html',
  styleUrls: ['./create-training.component.css'],
})
export class CreateTrainingComponent implements OnInit {
  createTrainingForm: FormGroup = new FormGroup({
    title: new FormControl(),
    description: new FormControl(),
    genre: new FormControl(),
    city: new FormControl(),
    address: new FormControl(),
    maxPetCount: new FormControl(),
    price: new FormControl(),
  });
  genres: GenreModel[] = [];
  createTrainingModel: CreateTrainingModel = new CreateTrainingModel(
    '',
    '',
    '',
    '',
    0,
    0,
    0,
    0
  );
  cities: CityModel[] = [];

  constructor(
    private genresService: GenresService,
    private formBuilder: FormBuilder,
    private trainingsService: TrainingsService,
    private citiesService: CitiesService,
    private authService: AuthService
  ) {}

  ngOnInit(): void {
    this.genresService.getGenres().subscribe((response) => {
      this.genres = response;
    });

    this.createTrainingForm = this.formBuilder.group({
      title: [, Validators.required],
      description: [, [Validators.required, Validators.minLength(10)]],
      genre: [, Validators.required],
      city: [, Validators.required],
      address: [, [Validators.required, Validators.minLength(5)]],
      maxPetCount: [, [Validators.required, Validators.min(1)]],
      price: [, [Validators.required, Validators.min(0)]],
    });

    this.citiesService.getCities().subscribe((response) => {
      let data: any = response;
      this.cities = data.data;
    });
  }

  createTraining(form: FormGroup) {
    this.createTrainingModel.title = form.value.title;
    this.createTrainingModel.description = form.value.description;
    this.createTrainingModel.city = form.value.city;
    this.createTrainingModel.address = form.value.address;
    this.createTrainingModel.maxPetCount = form.value.maxPetCount;
    this.createTrainingModel.genreId = form.value.genreId;
    this.createTrainingModel.userId = this.authService.getUserId();
    this.createTrainingModel.price = form.value.price;

    this.trainingsService.createTraining(this.createTrainingModel).subscribe(
      (response) => {
        //TODO: Create successfull method here:
      },
      (error) => {
        //TODO: Create failed method here:
      }
    );
  }
}
