import { Component, OnInit } from '@angular/core';
import {
  FormBuilder,
  FormControl,
  FormGroup,
  Validators,
} from '@angular/forms';
import { Router } from '@angular/router';
import { CreateEnrollmentModel } from 'src/app/models/CreateEnrollmentModel';
import { TrainingDetailModel } from 'src/app/models/TrainingDetailModel';
import { UserDetailViewModel } from 'src/app/models/UserDetailViewModel';
import { UserPetViewModel } from 'src/app/models/UserPetViewModel';
import { AuthService } from 'src/app/services/auth.service';
import { EnrollmentsService } from 'src/app/services/enrollments.service';
import { TrainingsService } from 'src/app/services/trainings.service';
import { UsersService } from 'src/app/services/users.service';

declare let alertify: any;

@Component({
  selector: 'app-create-enrollment',
  templateUrl: './create-enrollment.component.html',
  styleUrls: ['./create-enrollment.component.css'],
})
export class CreateEnrollmentComponent implements OnInit {
  user: UserDetailViewModel = new UserDetailViewModel('', '', '', '');
  pets: UserPetViewModel[] = [];
  training: TrainingDetailModel = new TrainingDetailModel(
    '',
    '',
    '',
    '',
    '',
    0,
    '',
    '',
    0
  );
  selectedTrainingId: number = 0;
  isPetSelected: boolean = false;
  selectPetForm: FormGroup = new FormGroup({
    petId: new FormControl(),
  });
  createEnrollmentModel: CreateEnrollmentModel = new CreateEnrollmentModel(
    0,
    0
  );

  constructor(
    private trainingsService: TrainingsService,
    private enrollmentsService: EnrollmentsService,
    private usersService: UsersService,
    private authService: AuthService,
    private router: Router,
    private formBuilder: FormBuilder
  ) {}

  ngOnInit(): void {
    this.selectPetForm = this.formBuilder.group({
      petId: [, Validators.required],
    });

    this.usersService
      .getUserDetail(this.authService.getUserId())
      .subscribe((response) => {
        this.user = response;
      });

    this.trainingsService.selectedTrainingId.subscribe((res) => {
      this.selectedTrainingId = res;
    });

    this.trainingsService
      .getTrainingDetail(this.selectedTrainingId)
      .subscribe((response) => {
        this.training = response;
        console.log(this.training);
      });

    this.usersService
      .getUserPets(this.authService.getUserId())
      .subscribe((response) => {
        this.pets = response;
      });
  }

  createEnrollment(form: FormGroup) {
    this.createEnrollmentModel.petId = parseInt(form.value.petId);
    this.createEnrollmentModel.trainingId = this.selectedTrainingId;

    this.enrollmentsService
      .createEnrollment(this.createEnrollmentModel)
      .subscribe(
        (response) => {
          if (response.status == 200) {
            alertify.success('Kayıt işlemi başarıyla tamamlandı.');
            this.router.navigate(['/trainings']);
          }
        },
        (error) => {
          alertify.error(error.error.error);
        }
      );
  }
}
