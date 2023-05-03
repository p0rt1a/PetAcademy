import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { GenreModel } from '../models/GenreModel';

@Injectable({
  providedIn: 'root',
})
export class GenresService {
  private url: string = 'https://localhost:5001/genres/';

  constructor(private http: HttpClient) {}

  getGenres(): Observable<GenreModel[]> {
    return this.http.get<GenreModel[]>(this.url);
  }
}
