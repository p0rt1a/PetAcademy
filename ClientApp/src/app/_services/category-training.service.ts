import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Category, CategoryTrainingDTO } from '../Models';

@Injectable({
  providedIn: 'root',
})
export class CategoryTrainingService {
  baseUrl: string = 'https://localhost:5001/api/categorytrainings/';

  constructor(private http: HttpClient) {}

  getCategoriesByTrainingId(id: number): Observable<CategoryTrainingDTO[]> {
    return this.http.get<CategoryTrainingDTO[]>(
      this.baseUrl + 'getCategories/' + id
    );
  }

  getTrainingsByCategoryId(id: number): Observable<CategoryTrainingDTO[]> {
    return this.http.get<CategoryTrainingDTO[]>(
      this.baseUrl + 'getTrainings/' + id
    );
  }
}
