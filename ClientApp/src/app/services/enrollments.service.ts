import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { CreateEnrollmentModel } from '../models/CreateEnrollmentModel';
import { environment } from 'src/environments/environment';

@Injectable({
  providedIn: 'root',
})
export class EnrollmentsService {
  private url: string = 'https://localhost:5001/enrollments';

  constructor(private http: HttpClient) {}

  createEnrollment(model: CreateEnrollmentModel) {
    return this.http.post(this.url, model, { observe: 'response' });
  }
}
