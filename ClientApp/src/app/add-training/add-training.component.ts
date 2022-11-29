import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { AddTrainingDTO, Category, Training } from '../Models';
import { AuthService } from '../_services/auth.service';
import { CategoriesService } from '../_services/categories.service';
import { TrainingsService } from '../_services/trainings.service';

@Component({
  selector: 'add-training',
  templateUrl: './add-training.component.html',
  styleUrls: ['./add-training.component.css'],
})
export class AddTrainingComponent implements OnInit {
  model: Training = new Training('', '', '', '', 0);
  modelCategory: number[] = [];
  categories?: Category[];

  constructor(
    private trainingService: TrainingsService,
    private authService: AuthService,
    private categoryService: CategoriesService,
    private router: Router
  ) {}

  ngOnInit(): void {
    this.getCategories();
  }

  addTraining() {
    //Adding to Training Table;
    var newUrl = this.model.videoUrl.split('v=', 2);

    this.model.trainerId = this.authService.getTrainerId();
    this.model.videoUrl = newUrl[1];

    var entity = new AddTrainingDTO(this.model, this.modelCategory);

    this.trainingService.addTraining(entity).subscribe(
      () => {
        this.router.navigate(['/home']);
      },
      (error) => {
        console.log('Error:' + error);
      }
    );
  }

  getCategories() {
    this.categoryService.getCategories().subscribe((response) => {
      this.categories = response;
    });
  }
}
