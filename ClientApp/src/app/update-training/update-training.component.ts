import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { Training } from '../Models';
import { AuthService } from '../_services/auth.service';
import { TrainingsService } from '../_services/trainings.service';

@Component({
  selector: 'update-training',
  templateUrl: './update-training.component.html',
  styleUrls: ['./update-training.component.css'],
})
export class UpdateTrainingComponent implements OnInit {
  trainings?: Training[];
  selectedModel: Training = new Training('', '', '', '', 0, 0);

  constructor(
    private trainingService: TrainingsService,
    private authService: AuthService,
    private router: Router
  ) {}

  ngOnInit(): void {
    this.getTrainingsByTrainerId();
  }

  deleteTraining(id: number) {
    this.trainingService.deleteTraining(id).subscribe(() => {
      console.log('Silme işlemi başarılı');
    });

    this.router.navigate(['/home']);
  }

  updateTraining(
    id: any,
    header: string,
    videoUrl: string,
    description: string,
    level: string
  ) {
    id = this.getSelectedTrainingId();

    var model = new Training(
      header,
      videoUrl,
      description,
      level,
      this.authService.getTrainerId(),
      id
    );

    this.trainingService.updateTraining(model.id, model).subscribe(() => {
      console.log('Güncelleme işlemi başarılı');
    });

    this.setSelectedTrainingId(0);

    this.router.navigate(['/home']);
  }

  getTrainingsByTrainerId() {
    this.trainingService
      .getTrainingsByTrainerId(this.authService.trainerId)
      .subscribe((response) => {
        this.trainings = response;
      });
  }

  getTrainingById(id: number) {
    this.trainingService.getTrainingById(id).subscribe((response) => {
      this.selectedModel = response;
    });
  }

  getSelectedTrainingId() {
    return this.trainingService.selectedTrainingId;
  }

  setSelectedTrainingId(id: number) {
    this.trainingService.selectedTrainingId = id;
  }
}
