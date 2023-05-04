import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { UserDetailViewModel } from '../models/UserDetailViewModel';
import { PetViewModel } from '../models/PetViewModel';
import { UserPetViewModel } from '../models/UserPetViewModel';

@Injectable({
  providedIn: 'root',
})
export class UsersService {
  private url: string = 'https://localhost:5001/users';

  constructor(private http: HttpClient) {}

  getUserDetail(id: number): Observable<UserDetailViewModel> {
    return this.http.get<UserDetailViewModel>(this.url + '/' + id);
  }

  getUserPets(id: number): Observable<UserPetViewModel[]> {
    return this.http.get<PetViewModel[]>(this.url + '/' + id + '/pets');
  }
}
