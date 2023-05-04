import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { RegisterModel } from '../models/RegisterModel';
import { LoginModel } from '../models/LoginModel';
import { catchError, map } from 'rxjs';
import { JwtHelperService } from '@auth0/angular-jwt';

@Injectable({
  providedIn: 'root',
})
export class AuthService {
  private url: string = 'https://localhost:5001/auth';
  private jwtHelper = new JwtHelperService();
  decodedToken: any;

  constructor(private http: HttpClient) {}

  register(model: RegisterModel) {
    return this.http.post(this.url + '/register', model, {
      observe: 'response',
    });
  }

  login(model: LoginModel) {
    return this.http
      .post(this.url + '/login', model, { observe: 'response' })
      .pipe(
        map((response: any) => {
          localStorage.setItem('token', response.accessToken);
          this.decodedToken = this.jwtHelper.decodeToken(response.accessToken);
        }),
        catchError((err) => {
          throw err;
        })
      );
  }
}
