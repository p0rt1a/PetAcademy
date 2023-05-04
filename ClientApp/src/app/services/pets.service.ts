import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { PetViewModel } from '../models/PetViewModel';
import { CreatePetModel } from '../models/CreatePetModel';

@Injectable({
  providedIn: 'root',
})
export class PetsService {
  private url: string = 'https://localhost:5001/pets';

  constructor(private http: HttpClient) {}

  getPetDetail(id: number): Observable<PetViewModel> {
    return this.http.get<PetViewModel>(this.url + '/' + id);
  }

  createPet(model: CreatePetModel) {
    return this.http.post(this.url, model, { observe: 'response' });
  }

  deletePet(id: number) {
    return this.http.delete(this.url + '/' + id);
  }
}
