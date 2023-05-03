import { Component, OnInit } from '@angular/core';
import { RegisterModel } from 'src/app/models/RegisterModel';
import { AuthService } from 'src/app/services/auth.service';

@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.css'],
})
export class RegisterComponent implements OnInit {
  registerModel: RegisterModel = new RegisterModel('', '', '', '');

  constructor(private authService: AuthService) {}

  ngOnInit(): void {}

  register() {
    this.authService.register(this.registerModel).subscribe(
      (response) => {
        //TODO: Create success alertify here:
        console.log(response.statusText);
      },
      (error) => {
        //TODO: Create failed alertify here:
        console.log(error.error.error);
      }
    );
  }
}
