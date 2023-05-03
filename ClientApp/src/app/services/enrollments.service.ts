import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { CreateEnrollmentModel } from '../models/CreateEnrollmentModel';

@Injectable({
  providedIn: 'root',
})
export class EnrollmentsService {
  private url: string = 'https://localhost:5001/enrollments';

  constructor(private http: HttpClient) {}

  createEnrollment(model: CreateEnrollmentModel) {
    this.http.post(this.url, model, { observe: 'response' });
  }
}
