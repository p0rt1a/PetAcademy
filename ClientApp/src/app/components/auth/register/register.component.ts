import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { RegisterModel } from 'src/app/models/RegisterModel';
import { AuthService } from 'src/app/services/auth.service';

declare let alertify: any;

@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.css'],
})
export class RegisterComponent implements OnInit {
  registerModel: RegisterModel = new RegisterModel('', '', '', '');

  constructor(private authService: AuthService, private router: Router) {}

  ngOnInit(): void {}

  register() {
    this.authService.register(this.registerModel).subscribe(
      (response) => {
        if (response.status == 200) {
          alertify.success('Kayıt işlemi başarılı.');
          this.router.navigate(['/login']);
        }
      },
      (error) => {
        alertify.error(error.error.error);
      }
    );
  }
}
