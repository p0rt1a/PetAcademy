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
  isMobile?: boolean;
  isClickedOnUser: boolean = false;

  constructor(private authService: AuthService, private router: Router) {}

  ngOnInit(): void {
    if (screen.width < 770) {
      this.isMobile = true;
    }
  }

  mobileClick() {
    this.isClickedOnUser = false;
  }

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

    console.log('Logged In');
  }

  logout() {
    localStorage.removeItem('token');
    this.router.navigate(['/home']);
  }
}
