import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { TrainingModel } from 'src/app/models/TrainingModel';
import { AuthService } from 'src/app/services/auth.service';
import { TrainingsService } from 'src/app/services/trainings.service';
import { UsersService } from 'src/app/services/users.service';

declare let alertify: any;

@Component({
  selector: 'app-my-trainings',
  templateUrl: './my-trainings.component.html',
  styleUrls: ['./my-trainings.component.css'],
})
export class MyTrainingsComponent implements OnInit {
  trainings: TrainingModel[] = [];

  constructor(
    private usersService: UsersService,
    private authService: AuthService,
    private trainingsService: TrainingsService,
    private router: Router
  ) {}

  ngOnInit(): void {
    this.usersService
      .getUserTrainings(this.authService.getUserId())
      .subscribe((response) => {
        console.log(response);
        this.trainings = response;
      });
  }

  updateTrainings(id: any) {
    this.trainingsService.setSelectedTrainingId(id);
    this.router.navigate(['/update-training']);
  }

  viewTraining(id: any) {
    this.trainingsService.setSelectedTrainingId(id);
    this.router.navigate(['/view-training']);
  }

  deleteTraining(id: any) {
    alertify.confirm(
      'Eğitim silinecektir, onaylıyor musunuz?',
      () => {
        this.trainingsService.deleteTraining(id).subscribe(
          (response) => {
            if (response.status == 200) {
              alertify.success('Eğitim başarıyla silindi');
              this.router.routeReuseStrategy.shouldReuseRoute = () => false;
              this.router.onSameUrlNavigation = 'reload';
              this.router.navigate(['/my-trainings']);
            }
          },
          (error) => {
            alertify.error(error.error.error);
          }
        );
      },
      () => {
        alertify.error('Cancel');
      }
    );
  }
}
