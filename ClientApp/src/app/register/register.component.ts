import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { AuthService } from '../_services/auth.service';

@Component({
  selector: 'register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.css'],
})
export class RegisterComponent {
  model: any = {};

  constructor(private authService: AuthService, private router: Router) {}

  register() {
    this.authService.register(this.model).subscribe(
      () => {
        this.router.navigate(['/home']);
      },
      (error) => {
        console.log('Error: ' + error);
      }
    );
  }
}
