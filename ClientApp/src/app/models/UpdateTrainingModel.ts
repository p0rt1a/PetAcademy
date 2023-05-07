export class UpdateTrainingModel {
  description: string;
  price: number;
  maxPetCount: number;

  constructor(description: string, price: number, maxPetCount: number) {
    this.description = description;
    this.price = price;
    this.maxPetCount = maxPetCount;
  }
}
