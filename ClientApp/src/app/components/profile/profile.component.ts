import { Component, OnInit } from '@angular/core';
import {
  FormBuilder,
  FormControl,
  FormGroup,
  Validators,
} from '@angular/forms';
import { CreatePetModel } from 'src/app/models/CreatePetModel';
import { GenreModel } from 'src/app/models/GenreModel';
import { PetViewModel } from 'src/app/models/PetViewModel';
import { UpdatePetModel } from 'src/app/models/UpdatePetModel';
import { UpdateUserModel } from 'src/app/models/UpdateUserModel';
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
  createPetForm: FormGroup = new FormGroup({
    name: new FormControl(),
    genre: new FormControl(),
    age: new FormControl(),
  });
  createPetModel: CreatePetModel = new CreatePetModel('', 0, 0, 0);
  updatePetModel: UpdatePetModel = new UpdatePetModel(0, '', 0);
  isUpdatingPet: boolean = false;
  pets: UserPetViewModel[] = [];
  genres: GenreModel[] = [];
  pet: PetViewModel = new PetViewModel(0, '', 0, '');
  petUpdateModel: UpdatePetModel = new UpdatePetModel(0, '', 0);
  updatePetForm: FormGroup = new FormGroup({
    name: new FormControl(),
    age: new FormControl(),
  });
  user: UserDetailViewModel = new UserDetailViewModel('', '', '');
  updateUserModel: UpdateUserModel = new UpdateUserModel('');

  updateUserForm: FormGroup = new FormGroup({
    email: new FormControl(),
  });

  constructor(
    private formBuilder: FormBuilder,
    private usersService: UsersService,
    private authService: AuthService,
    private genresService: GenresService,
    private petsService: PetsService
  ) {}

  ngOnInit(): void {
    this.createPetForm = this.formBuilder.group({
      name: [, [Validators.required, Validators.minLength(2)]],
      genre: [, Validators.required],
      age: [, [Validators.required, Validators.min(0)]],
    });

    this.updateUserForm = this.formBuilder.group({
      email: [, Validators.email],
    });

    this.usersService
      .getUserDetail(this.authService.getUserId())
      .subscribe((response) => {
        this.user = response;
      });

    this.genresService.getGenres().subscribe((response) => {
      this.genres = response;
    });

    this.usersService
      .getUserPets(this.authService.getUserId())
      .subscribe((response) => {
        this.pets = response;
      });
  }

  getPetDetail(id: any) {
    this.petsService.getPetDetail(id).subscribe((response) => {
      this.pet = response;
    });
  }

  updatePet(id: any) {
    this.updatePetModel.userId = this.authService.getUserId();

    this.petsService.updatePet(id, this.updatePetModel).subscribe(
      (response) => {
        console.log(response);
      },
      (error) => {
        console.log(error);
      }
    );
  }

  updateUser(form: FormGroup) {
    this.updateUserModel.email = form.value.email;

    let userId: number = this.authService.getUserId();
    this.usersService.updateUser(userId, this.updateUserModel).subscribe(
      (response) => {
        //TODO: Create success method here:
        console.log('Güncelleme başarılı');
      },
      (error) => {
        //TODO: Create fail method here:
        console.log(error.error.error);
      }
    );
  }

  createPet(form: FormGroup) {
    this.createPetModel.name = form.value.name;
    this.createPetModel.age = form.value.age;
    this.createPetModel.genreId = parseInt(form.value.genre);
    this.createPetModel.userId = this.authService.getUserId();

    this.petsService.createPet(this.createPetModel).subscribe(
      (response) => {
        //TODO: Create successfull method here:
      },
      (error) => {
        //TODO: Create failed method here:
      }
    );
  }

  deletePet(id: any) {
    this.petsService.deletePet(id).subscribe(
      (response) => {
        if (response.status == 200) {
          console.log('Silme işlemi başarılı');
        }
      },
      (error) => {
        console.log(error);
      }
    );
  }
}
