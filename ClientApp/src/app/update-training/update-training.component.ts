import { Component, OnInit } from '@angular/core';
import { Category, Training, TrainingDTO } from '../Models';
import { AuthService } from '../_services/auth.service';
import { CategoriesService } from '../_services/categories.service';
import { TrainingsService } from '../_services/trainings.service';

@Component({
  selector: 'app-update-training',
  templateUrl: './update-training.component.html',
  styleUrls: ['./update-training.component.css'],
})
export class UpdateTrainingComponent implements OnInit {
  trainings?: Training[];
  // model: Training = new Training('', '', '', '');
  // selectedModel: Training = new Training('', '', '', '', 0, 0);

  constructor(
    private trainingService: TrainingsService,
    private authService: AuthService
  ) {}

  ngOnInit(): void {
    this.getTrainingsByTrainerId();
  }

  // updateTraining() {
  //   this.trainingService.updateTraining(this.model);
  // }

  deleteTraining(id: number) {
    this.trainingService.deleteTraining(id).subscribe(() => {
      console.log('Silme işlemi başarılı');
    });
  }

  getTrainingsByTrainerId() {
    this.trainingService
      .getTrainingsByTrainerId(this.authService.trainerId)
      .subscribe((response) => {
        this.trainings = response;
      });
  }

  setSelectedTrainingId(id: number) {
    this.trainingService.selectedTrainingId = id;
  }

  // getSelectedTraining() {
  //   this.trainingService
  //     .getTrainingById(this.getSelectedTrainingId())
  //     .subscribe((response) => {
  //       this.selectedModel = response;
  //     });
  // }

  getSelectedTrainingId() {
    return this.trainingService.selectedTrainingId;
  }
}
