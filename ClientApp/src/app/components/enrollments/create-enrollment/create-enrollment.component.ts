import { Component, OnInit } from '@angular/core';
import { CreateEnrollmentModel } from 'src/app/models/CreateEnrollmentModel';
import { TrainingDetailModel } from 'src/app/models/TrainingDetailModel';
import { UserDetailViewModel } from 'src/app/models/UserDetailViewModel';
import { UserPetViewModel } from 'src/app/models/UserPetViewModel';
import { AuthService } from 'src/app/services/auth.service';
import { EnrollmentsService } from 'src/app/services/enrollments.service';
import { TrainingsService } from 'src/app/services/trainings.service';
import { UsersService } from 'src/app/services/users.service';

@Component({
  selector: 'app-create-enrollment',
  templateUrl: './create-enrollment.component.html',
  styleUrls: ['./create-enrollment.component.css'],
})
export class CreateEnrollmentComponent implements OnInit {
  user: UserDetailViewModel = new UserDetailViewModel('', '', '');
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

  constructor(
    private trainingsService: TrainingsService,
    private enrollmentsService: EnrollmentsService,
    private usersService: UsersService,
    private authService: AuthService
  ) {}

  ngOnInit(): void {
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
      });

    this.usersService
      .getUserPets(this.authService.getUserId())
      .subscribe((response) => {
        response.forEach((element) => {
          if (
            element.genre.toLowerCase() == this.training.genre.toLowerCase()
          ) {
            this.pets.push(element);
          }
        });
      });
  }

  createEnrollment(petId: any) {
    let model = new CreateEnrollmentModel(
      parseInt(petId),
      this.selectedTrainingId
    );

    console.log(model);

    this.enrollmentsService.createEnrollment(model).subscribe(
      (response) => {
        console.log(response);
      },
      (error) => {
        console.log(error);
      }
    );
  }
}
