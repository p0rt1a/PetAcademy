import { Injectable } from '@angular/core';
import { CanActivate, Router } from '@angular/router';
import { AuthService } from '../services/auth.service';

declare let alertify: any;

@Injectable({
  providedIn: 'root',
})
export class AuthGuard implements CanActivate {
  constructor(private authService: AuthService, private router: Router) {}

  canActivate() {
    if (!this.authService.isTokenExpired()) {
      return true;
    }

    alertify.error('Bunun için giriş yapmalısınız!');
    this.router.navigate(['/login']);
    return false;
  }
}
