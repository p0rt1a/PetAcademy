import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { CreateCertificateModel } from '../models/CreateCertificateModel';

@Injectable({
  providedIn: 'root',
})
export class CertificateService {
  url: string = 'https://localhost:5001/certificates';

  constructor(private http: HttpClient) {}

  createCertificate(model: CreateCertificateModel) {
    return this.http.post(this.url, model, { observe: 'response' });
  }
}
