import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { JwtHelperService } from '@auth0/angular-jwt';
import { map, Observable } from 'rxjs';

@Injectable({
  providedIn: 'root',
})
export class AuthService {
  baseUrl: string = 'https://localhost:5001/api/user/';
  jwtHelper = new JwtHelperService();
  decodedToken: any;
  isTrainer?: boolean;
  trainerId: number = 0;

  constructor(private http: HttpClient) {}

  login(model: any) {
    return this.http.post(this.baseUrl + 'login', model).pipe(
      map((response: any) => {
        var result = response;

        this.isTrainer = response.isTrainer;

        if (this.isTrainer) {
          this.trainerId = result.id;
        }
        if (result) {
          localStorage.setItem('token', result.token);
        }
      })
    );
  }

  register(model: any) {
    return this.http.post(this.baseUrl + 'register', model);
  }

  isLoggedIn() {
    const token = localStorage.getItem('token');
    return !this.jwtHelper.isTokenExpired(token?.toString());
  }

  getIsTrainer() {
    return this.isTrainer;
  }

  getTrainerId() {
    return this.trainerId;
  }
}
