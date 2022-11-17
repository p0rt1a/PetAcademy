import { Component, OnInit } from '@angular/core';
import { Pet } from '../Models';
import { PetsService } from '../_services/pets.service';

@Component({
  selector: 'categories',
  templateUrl: './categories.component.html',
  styleUrls: ['./categories.component.css'],
})
export class CategoriesComponent implements OnInit {
  pets?: Pet[];

  constructor(private petsService: PetsService) {}

  ngOnInit(): void {
    this.getPets();
  }

  getPets() {
    this.petsService.getPets().subscribe((response) => {
      console.log(response);
      this.pets = response;
    });
  }
}
