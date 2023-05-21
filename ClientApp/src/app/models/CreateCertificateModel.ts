export class CreateCertificateModel {
  petId: number;
  trainingId: number;

  constructor(petId: number, trainingId: number) {
    this.petId = petId;
    this.trainingId = trainingId;
  }
}
