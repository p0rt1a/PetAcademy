import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { CityModel } from '../models/CityModel';

@Injectable({
  providedIn: 'root',
})
export class CitiesService {
  url: string = 'https://turkiyeapi.cyclic.app/api/v1/provinces';

  constructor(private http: HttpClient) {}

  getCities(): Observable<CityModel[]> {
    return this.http.get<CityModel[]>(this.url);
  }
}
