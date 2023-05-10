import { Injectable } from '@angular/core';
import { CanActivate, Router } from '@angular/router';
import { AuthService } from '../services/auth.service';

@Injectable({
  providedIn: 'root',
})
export class AuthGuard implements CanActivate {
  constructor(private authService: AuthService, private router: Router) {}

  canActivate() {
    if (!this.authService.isTokenExpired()) {
      return true;
    }

    //TODO: Navigate to unauthorized page:
    this.router.navigate(['/trainings']);
    return false;
  }
}
