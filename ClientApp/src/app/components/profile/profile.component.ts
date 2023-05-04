import { Component, OnInit } from '@angular/core';
import { PetViewModel } from 'src/app/models/PetViewModel';
import { UserDetailViewModel } from 'src/app/models/UserDetailViewModel';
import { UserPetViewModel } from 'src/app/models/UserPetViewModel';
import { AuthService } from 'src/app/services/auth.service';
import { PetsService } from 'src/app/services/pets.service';
import { UsersService } from 'src/app/services/users.service';

@Component({
  selector: 'app-profile',
  templateUrl: './profile.component.html',
  styleUrls: ['./profile.component.css'],
})
export class ProfileComponent implements OnInit {
  user: UserDetailViewModel = new UserDetailViewModel('', '', '');
  pets: UserPetViewModel[] = [];

  constructor(
    private authService: AuthService,
    private usersService: UsersService,
    private petsService: PetsService
  ) {}

  ngOnInit(): void {
    this.usersService
      .getUserDetail(this.authService.getUserId())
      .subscribe((response) => {
        this.user = response;
      });

    this.usersService
      .getUserPets(this.authService.getUserId())
      .subscribe((response) => {
        this.pets = response;
      });
  }
}
