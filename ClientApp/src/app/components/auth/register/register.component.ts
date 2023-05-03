import { Component, OnInit } from '@angular/core';
import { RegisterModel } from 'src/app/models/RegisterModel';

@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.css'],
})
export class RegisterComponent implements OnInit {
  registerModel: RegisterModel = new RegisterModel('', '', '', '');

  constructor() {}

  ngOnInit(): void {}

  register() {
    console.log(this.registerModel);
  }
}
