import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root',
})
export class PetsService {
  baseUrl: string = 'http://localhost:5000/api/pets/';

  constructor(private http: HttpClient) {}

  getPets() {
    return this.http.get(this.baseUrl);
  }
}
