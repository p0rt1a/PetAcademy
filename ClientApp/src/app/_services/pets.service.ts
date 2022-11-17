import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Pet } from '../Models';

@Injectable({
  providedIn: 'root',
})
export class PetsService {
  baseUrl: string = 'http://localhost:5000/api/pets/';

  constructor(private http: HttpClient) {}

  getPets(): Observable<Pet[]> {
    return this.http.get<Pet[]>(this.baseUrl);
  }
}
