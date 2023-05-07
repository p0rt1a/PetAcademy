import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { PetViewModel } from '../models/PetViewModel';
import { CreatePetModel } from '../models/CreatePetModel';
import { UpdatePetModel } from '../models/UpdatePetModel';

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
    return this.http.delete(this.url + '/' + id, { observe: 'response' });
  }

  updatePet(id: number, model: UpdatePetModel) {
    return this.http.put(this.url + '/' + id, model, { observe: 'response' });
  }
}
