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
  defaultSelectedAnimal: string = 'Tüm Hayvanlar';

  constructor(private categoryService: CategoriesService) {}

  ngOnInit(): void {
    this.getCategories();
  }

  changeSelectedAnimal(categoryId: any) {
    this.categoryChange.emit(categoryId.target.value);
  }

  changeSelectedLevel(levelName: any) {
    console.log(levelName.target.value);
  }

  getSearch(text: any) {
    console.log(text);
  }

  getCategories() {
    this.categoryService.getCategories().subscribe((response) => {
      this.categories = response;
    });
  }
}
