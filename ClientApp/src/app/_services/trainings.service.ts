import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Training, TrainingDTO } from '../Models';

@Injectable({
  providedIn: 'root',
})
export class TrainingsService {
  baseUrl: string = 'https://localhost:5001/api/trainings/';
  selectedTrainingId: number = 0;

  constructor(private http: HttpClient) {}

  getTrainings(): Observable<Training[]> {
    return this.http.get<Training[]>(this.baseUrl);
  }

  getTrainingById(id: number): Observable<Training> {
    return this.http.get<Training>(this.baseUrl + id);
  }

  addTraining(training: TrainingDTO) {
    return this.http.post(this.baseUrl, training);
  }

  getTrainingsByTrainerId(trainerId: number): Observable<Training[]> {
    return this.http.get<Training[]>(
      this.baseUrl + 'trainings-by-trainer/' + trainerId
    );
  }

  getTrainingsByCategoryId(id: number): Observable<Training[]> {
    return this.http.get<Training[]>(
      this.baseUrl + 'trainings-by-category/' + id
    );
  }

  deleteTraining(id: number) {
    return this.http.delete(this.baseUrl + id);
  }

  updateTraining(id: number, model: Training) {
    return this.http.put(this.baseUrl + id, model);
  }
}
