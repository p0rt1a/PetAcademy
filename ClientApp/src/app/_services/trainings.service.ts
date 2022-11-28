import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { AddTrainingDTO, Training, TrainingDTO } from '../Models';
import { AuthService } from './auth.service';

@Injectable({
  providedIn: 'root',
})
export class TrainingsService {
  baseUrl: string = 'https://localhost:5001/api/trainings/';

  constructor(private http: HttpClient) {}

  getTrainings(): Observable<Training[]> {
    return this.http.get<Training[]>(this.baseUrl);
  }

  addTraining(training: AddTrainingDTO) {
    return this.http.post(this.baseUrl + 'add', training);
  }

  getTrainingById(id: number): Observable<Training> {
    return this.http.get<Training>(this.baseUrl + id);
  }

  getTrainingDTOById(id: number): Observable<TrainingDTO> {
    return this.http.get<TrainingDTO>(this.baseUrl + 'trainingDto' + id);
  }

  getTrainingsByTrainerId(trainerId: number): Observable<Training[]> {
    return this.http.get<Training[]>(this.baseUrl + 'trainer/' + trainerId);
  }
}
