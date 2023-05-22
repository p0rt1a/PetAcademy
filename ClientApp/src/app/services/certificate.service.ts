import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { CreateCertificateModel } from '../models/CreateCertificateModel';
import { BehaviorSubject } from 'rxjs';
import { PetCertificateViewModel } from '../models/PetCertificateViewModel';

@Injectable({
  providedIn: 'root',
})
export class CertificateService {
  private certificateSubject = new BehaviorSubject(
    new PetCertificateViewModel('', '', '')
  );
  certificate = this.certificateSubject.asObservable();

  url: string = 'https://localhost:5001/certificates';

  constructor(private http: HttpClient) {}

  createCertificate(model: CreateCertificateModel) {
    return this.http.post(this.url, model, { observe: 'response' });
  }

  setCertificate(model: PetCertificateViewModel) {
    this.certificateSubject.next(model);
  }
}
