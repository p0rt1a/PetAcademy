import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormControl, FormGroup } from '@angular/forms';
import { Router } from '@angular/router';
import { TrainingDetailModel } from 'src/app/models/TrainingDetailModel';
import { UpdateTrainingModel } from 'src/app/models/UpdateTrainingModel';
import { TrainingsService } from 'src/app/services/trainings.service';

declare let alertify: any;

@Component({
  selector: 'app-update-training',
  templateUrl: './update-training.component.html',
  styleUrls: ['./update-training.component.css'],
})
export class UpdateTrainingComponent implements OnInit {
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
  updateTrainingModel: UpdateTrainingModel = new UpdateTrainingModel('', 0, 0);
  updateTrainingForm: FormGroup = new FormGroup({
    description: new FormControl(),
    price: new FormControl(),
    maxPetCount: new FormControl(),
  });

  constructor(
    private trainingsService: TrainingsService,
    private router: Router
  ) {}

  ngOnInit(): void {
    this.trainingsService.selectedTrainingId.subscribe(
      (response) => (this.selectedTrainingId = response)
    );

    this.trainingsService
      .getTrainingDetail(this.selectedTrainingId)
      .subscribe((response) => {
        this.training = response;
      });
  }

  updateTraining(form: FormGroup) {
    this.updateTrainingModel.description = form.value.description
      ? form.value.description
      : '';
    this.updateTrainingModel.maxPetCount = form.value.maxPetCount
      ? form.value.maxPetCount
      : 0;
    this.updateTrainingModel.price = form.value.price ? form.value.price : 0;

    alertify.confirm(
      'Eğitim güncellenecektir, onaylıyor musunuz?',
      () => {
        this.trainingsService
          .updateTraining(this.selectedTrainingId, this.updateTrainingModel)
          .subscribe(
            (response) => {
              if (response.status == 200) {
                alertify.success('Eğitim başarıyla güncellendi.');
                this.router.routeReuseStrategy.shouldReuseRoute = () => false;
                this.router.onSameUrlNavigation = 'reload';
                this.router.navigate(['/update-training']);
              }
            },
            (error) => {
              alertify.error(error.error.error);
            }
          );
      },
      () => {}
    );
  }
}
