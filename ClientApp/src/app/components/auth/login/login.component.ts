import { Component, OnInit } from '@angular/core';
import { LoginModel } from 'src/app/models/LoginModel';
import { AuthService } from 'src/app/services/auth.service';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css'],
})
export class LoginComponent implements OnInit {
  loginModel: LoginModel = new LoginModel('', '');

  constructor(private authService: AuthService) {}

  ngOnInit(): void {}

  login() {
    this.authService.login(this.loginModel).subscribe(
      (response) => {
        //TODO: Create successfull response operations
        console.log(response);
      },
      (error) => {
        //TODO: Create error message
        console.log(error.error.error);
      }
    );
  }
}
