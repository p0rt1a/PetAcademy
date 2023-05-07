import { Component, OnInit } from '@angular/core';
import { FormControl, Validators } from '@angular/forms';
import { CreatePetModel } from 'src/app/models/CreatePetModel';
import { GenreModel } from 'src/app/models/GenreModel';
import { PetViewModel } from 'src/app/models/PetViewModel';
import { UpdatePetModel } from 'src/app/models/UpdatePetModel';
import { UserDetailViewModel } from 'src/app/models/UserDetailViewModel';
import { UserPetViewModel } from 'src/app/models/UserPetViewModel';
import { AuthService } from 'src/app/services/auth.service';
import { GenresService } from 'src/app/services/genres.service';
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
  pet: PetViewModel = new PetViewModel(0, '', 0, '');
  updatePetModel: UpdatePetModel = new UpdatePetModel(0, '', 0);
  isPetIdSelected: boolean = false;
  genres: GenreModel[] = [];
  createPetModel: CreatePetModel = new CreatePetModel('', 0, 0, 0);

  selectedControl: FormControl = new FormControl('value', Validators.min(0));

  constructor(
    private authService: AuthService,
    private usersService: UsersService,
    private petsService: PetsService,
    private genresService: GenresService
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

    this.genresService.getGenres().subscribe((response) => {
      this.genres = response;
    });
  }

  getPetDetail(id: any) {
    this.petsService.getPetDetail(id).subscribe((response) => {
      console.log(response);
      this.pet = response;
    });
  }

  updatePet(id: any) {
    this.updatePetModel.userId = this.authService.getUserId();

    this.petsService
      .updatePet(id, this.updatePetModel)
      .subscribe((response) => {
        if (response.status == 200) {
          //TODO: Create your OK logic
        }
      });
  }

  deletePet(id: any) {
    this.petsService.deletePet(id).subscribe((response) => {
      console.log(response);
    });
  }

  createPet() {
    this.createPetModel.userId = this.authService.getUserId();
    console.log(this.createPetModel);
  }
}
