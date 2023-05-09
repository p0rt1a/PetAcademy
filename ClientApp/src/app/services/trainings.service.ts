import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { TrainingModel } from '../models/TrainingModel';
import { BehaviorSubject, Observable } from 'rxjs';
import { TrainingDetailModel } from '../models/TrainingDetailModel';
import { TrainingCommentViewModel } from '../models/TrainingCommentViewModel';
import { CreateTrainingModel } from '../models/CreateTrainingModel';
import { TrainingPetViewModel } from '../models/TrainingPetViewModel';

@Injectable({
  providedIn: 'root',
})
export class TrainingsService {
  private url: string = 'https://localhost:5001/trainings';
  //TODO: Set selected training id to 0
  private selectedTrainingIdSubject = new BehaviorSubject(1);
  selectedTrainingId = this.selectedTrainingIdSubject.asObservable();

  constructor(private http: HttpClient) {}

  getTrainings(): Observable<TrainingModel[]> {
    return this.http.get<TrainingModel[]>(this.url);
  }

  getTrainingsByFilter(
    title: string,
    city: string,
    genre: string
  ): Observable<TrainingModel[]> {
    return this.http.get<TrainingModel[]>(
      this.url + '?title=' + title + '&city=' + city + '&genre=' + genre
    );
  }

  getTrainingDetail(id: number): Observable<TrainingDetailModel> {
    return this.http.get<TrainingDetailModel>(this.url + '/' + id);
  }

  setSelectedTrainingId(id: number) {
    this.selectedTrainingIdSubject.next(id);
  }

  getTrainingComments(id: number): Observable<TrainingCommentViewModel[]> {
    return this.http.get<TrainingCommentViewModel[]>(
      this.url + '/' + id + '/comments'
    );
  }

  createTraining(model: CreateTrainingModel) {
    return this.http.post(this.url, model, { observe: 'response' });
  }

  getTrainingPets(id: number): Observable<TrainingPetViewModel[]> {
    return this.http.get<TrainingPetViewModel[]>(this.url + '/' + id + '/pets');
  }
}
