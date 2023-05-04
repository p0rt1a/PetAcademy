import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { LoginModel } from 'src/app/models/LoginModel';
import { AuthService } from 'src/app/services/auth.service';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css'],
})
export class LoginComponent implements OnInit {
  loginModel: LoginModel = new LoginModel('', '');

  constructor(private authService: AuthService, private router: Router) {}

  ngOnInit(): void {}

  login() {
    this.authService.login(this.loginModel).subscribe(
      () => {
        console.log('Başarılı');
        this.router.navigate(['trainings']);
      },
      (error) => {
        console.log(error);
      }
    );
  }
}