import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { TrainingModel } from '../models/TrainingModel';
import { BehaviorSubject, Observable } from 'rxjs';

@Injectable({
  providedIn: 'root',
})
export class TrainingsService {
  url: string = 'https://localhost:5001/trainings';
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

  getTrainingDetail(id: number) {
    return this.http.get(this.url + '/' + id);
  }

  setSelectedTrainingId(id: number) {
    this.selectedTrainingIdSubject.next(id);
  }
}
