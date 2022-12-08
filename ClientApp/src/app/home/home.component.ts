import { Component, OnInit } from '@angular/core';
import { Category } from '../Models';
import { CategoriesService } from '../_services/categories.service';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.css'],
})
export class HomeComponent implements OnInit {
  selectedCategory?: number;
  categories?: Category[];

  constructor(private categoryService: CategoriesService) {}

  ngOnInit(): void {
    this.categoryService.getCategories().subscribe((response) => {
      this.categories = response;
    });
  }

  getSelectedCategory(categoryId: number) {
    this.selectedCategory = categoryId;
  }
}
