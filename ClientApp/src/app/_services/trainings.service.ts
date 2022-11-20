import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { AddTrainingDTO, Training } from '../Models';

@Injectable({
  providedIn: 'root',
})
export class TrainingsService {
  baseUrl: string = 'https://localhost:5001/api/trainings/';

  constructor(private http: HttpClient) {}

  getTrainings(): Observable<Training[]> {
    return this.http.get<Training[]>(this.baseUrl);
  }

  addTraining(addTrainingDTO: AddTrainingDTO) {
    return this.http.post(this.baseUrl + 'add', addTrainingDTO);
  }

  getTrainingById(id: number): Observable<Training> {
    return this.http.get<Training>(this.baseUrl + id);
  }
}
