export class PetCertificateViewModel {
  trainingTitle: string;
  graduateDate: string;
  petName: string;

  constructor(trainingTitle: string, graduateDate: string, petName: string) {
    this.trainingTitle = trainingTitle;
    this.graduateDate = graduateDate;
    this.petName = petName;
  }
}
