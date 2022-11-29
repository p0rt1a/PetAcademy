import { Component, EventEmitter, OnInit, Output } from '@angular/core';
import { Category } from '../Models';
import { CategoriesService } from '../_services/categories.service';

@Component({
  selector: 'categories',
  templateUrl: './categories.component.html',
  styleUrls: ['./categories.component.css'],
})
export class CategoriesComponent implements OnInit {
  @Output() categoryChange = new EventEmitter<number>();
  categories?: Category[];

  constructor(private categoryService: CategoriesService) {}

  ngOnInit(): void {
    this.getCategories();
  }

  changeSelectedCategory(categoryId: number) {
    this.categoryChange.emit(categoryId);
  }

  getCategories() {
    this.categoryService.getCategories().subscribe((response) => {
      this.categories = response;
    });
  }
}
