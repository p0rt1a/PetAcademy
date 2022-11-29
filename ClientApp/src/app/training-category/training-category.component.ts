import { Component, Input, OnInit } from '@angular/core';
import { VirtualTimeScheduler } from 'rxjs';
import { Category, CategoryTrainingDTO } from '../Models';
import { CategoriesService } from '../_services/categories.service';
import { CategoryTrainingService } from '../_services/category-training.service';

@Component({
  selector: 'training-category',
  templateUrl: './training-category.component.html',
  styleUrls: ['./training-category.component.css'],
})
export class TrainingCategoryComponent implements OnInit {
  @Input() trainingId?: number;
  categoryTrainings?: CategoryTrainingDTO[];
  categories: Category[] = [];

  constructor(
    private categoryService: CategoriesService,
    private categoryTrainingService: CategoryTrainingService
  ) {}

  ngOnInit(): void {
    if (this.trainingId != null) {
      this.getCategoryTrainingsByTrainingId(this.trainingId);
    }
  }

  getCategoryTrainingsByTrainingId(id: number) {
    this.categoryTrainingService
      .getCategoriesByTrainingId(id)
      .subscribe((response) => {
        this.categoryTrainings = response;

        this.categoryTrainings?.forEach((element) => {
          this.getCategories(element.categoryId);
        });
      });
  }

  getCategories(id: number) {
    this.categoryService.getCategoryById(id).subscribe((response) => {
      this.categories.push(response);
    });
  }
}
