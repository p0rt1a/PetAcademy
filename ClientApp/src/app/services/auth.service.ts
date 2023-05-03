import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { RegisterModel } from '../models/RegisterModel';

@Injectable({
  providedIn: 'root',
})
export class AuthService {
  private url: string = 'https://localhost:5001/auth';

  constructor(private http: HttpClient) {}

  register(model: RegisterModel) {
    return this.http.post(this.url + '/register', model, {
      observe: 'response',
    });
  }
}
