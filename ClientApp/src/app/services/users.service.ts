import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { UserDetailViewModel } from '../models/UserDetailViewModel';
import { PetViewModel } from '../models/PetViewModel';
import { UserPetViewModel } from '../models/UserPetViewModel';
import { TrainingModel } from '../models/TrainingModel';
import { UpdateUserModel } from '../models/UpdateUserModel';

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

  getUserTrainings(id: number): Observable<TrainingModel[]> {
    return this.http.get<TrainingModel[]>(this.url + '/' + id + '/trainings');
  }

  updateUser(id: number, model: UpdateUserModel) {
    return this.http.put(this.url + '/' + id, model, { observe: 'response' });
  }
}
