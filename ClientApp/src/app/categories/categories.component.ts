import { Component, OnInit } from '@angular/core';
import { Category } from '../Models';
import { CategoriesService } from '../_services/categories.service';

@Component({
  selector: 'categories',
  templateUrl: './categories.component.html',
  styleUrls: ['./categories.component.css'],
})
export class CategoriesComponent implements OnInit {
  categories?: Category[];

  constructor(private categoryService: CategoriesService) {}

  ngOnInit(): void {
    this.getPets();
  }

  getPets() {
    this.categoryService.getCategories().subscribe((response) => {
      this.categories = response;
    });
  }
}
