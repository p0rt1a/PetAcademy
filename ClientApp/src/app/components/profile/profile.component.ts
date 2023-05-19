import { Component, OnInit } from '@angular/core';
import {
  FormBuilder,
  FormControl,
  FormGroup,
  Validators,
} from '@angular/forms';
import { Router } from '@angular/router';
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

declare let alertify: any;

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
  user: UserDetailViewModel = new UserDetailViewModel('', '', '', '');
  updateUserModel: UpdateUserModel = new UpdateUserModel('', '');
  imgUrl: string = '';

  updateUserForm: FormGroup = new FormGroup({
    email: new FormControl(),
  });

  constructor(
    private formBuilder: FormBuilder,
    private usersService: UsersService,
    private authService: AuthService,
    private genresService: GenresService,
    private petsService: PetsService,
    private router: Router
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

  onFileLoaded(event: any) {
    var file: File = event.target.files[0];
    const reader = new FileReader();
    reader.onload = () => {
      const dataURL = reader.result as string;
      this.convertToImageBitmap(dataURL);
    };
    reader.readAsDataURL(file);
  }

  convertToImageBitmap(dataURL: string) {
    fetch(dataURL)
      .then((response) => response.blob())
      .then((blob) => createImageBitmap(blob))
      .then((imageBitmap) => {
        this.convertImageToBase64(imageBitmap);
      })
      .catch((error) => console.timeLog(error));
  }

  convertImageToBase64(image: ImageBitmap) {
    const img = image;
    const canvas = document.createElement('canvas');
    const cts = canvas.getContext('2d');

    canvas.width = img.width;
    canvas.height = img.height;

    cts?.drawImage(img, 0, 0);

    const dataURL = canvas.toDataURL('image/png');
    this.imgUrl = dataURL;
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
        if (response.status == 200) {
          alertify.success('Güncelleme başarıyla tamamlandı.');
          this.router.routeReuseStrategy.shouldReuseRoute = () => false;
          this.router.onSameUrlNavigation = 'reload';
          this.router.navigate(['/profile']);
        }
      },
      (error) => {
        alertify.error(error.error.error);
      }
    );
  }

  updateUser(form: FormGroup) {
    form.value.email =
      form.value.email != null ? form.value.email : this.user.email;
    this.updateUserModel.email = form.value.email;
    this.updateUserModel.image =
      this.imgUrl != '' ? this.imgUrl.split(',', 2)[1] : '';

    let userId: number = this.authService.getUserId();
    this.usersService.updateUser(userId, this.updateUserModel).subscribe(
      (response) => {
        if (response.status == 200) {
          alertify.success('Güncelleme işlemi başarılı.');
          this.router.routeReuseStrategy.shouldReuseRoute = () => false;
          this.router.onSameUrlNavigation = 'reload';
          this.router.navigate(['/profile']);
        }
      },
      (error) => {
        alertify.error(error.error.error);
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
        if (response.status == 200) {
          alertify.success('Ekleme işlemi başarılı.');
          this.router.routeReuseStrategy.shouldReuseRoute = () => false;
          this.router.onSameUrlNavigation = 'reload';
          this.router.navigate(['/profile']);
        }
      },
      (error) => {
        alertify.error(error.error.error);
      }
    );
  }

  deletePet(id: any) {
    this.petsService.deletePet(id).subscribe(
      (response) => {
        if (response.status == 200) {
          alertify.success('Silme işlemi başarılı.');
          this.router.routeReuseStrategy.shouldReuseRoute = () => false;
          this.router.onSameUrlNavigation = 'reload';
          this.router.navigate(['/profile']);
        }
      },
      (error) => {
        alertify.error(error.error.error);
      }
    );
  }
}
