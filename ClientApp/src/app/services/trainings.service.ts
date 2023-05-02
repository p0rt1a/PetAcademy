import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root',
})
export class TrainingsService {
  url: string = 'https://localhost:5001/trainings/';

  constructor(private http: HttpClient) {}

  getTrainings() {
    return this.http.get(this.url);
  }

  getTrainingDetails(id: number) {
    return this.http.get(this.url + id);
  }
}
