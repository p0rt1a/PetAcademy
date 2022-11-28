import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { AuthService } from '../_services/auth.service';

@Component({
  selector: 'navbar',
  templateUrl: './navbar.component.html',
  styleUrls: ['./navbar.component.css'],
})
export class NavbarComponent implements OnInit {
  model: any = {};
  isTrainer?: boolean;

  constructor(private authService: AuthService, private router: Router) {}

  ngOnInit(): void {}

  isLoggedIn() {
    return this.authService.isLoggedIn();
  }

  getTrainerInformation() {
    this.isTrainer = this.authService.getIsTrainer();
  }

  login() {
    this.authService.login(this.model).subscribe((response) => {
      this.router.navigate(['/home']);
      this.getTrainerInformation();
    });
  }

  logout() {
    localStorage.removeItem('token');
    this.router.navigate(['/home']);
  }
}
