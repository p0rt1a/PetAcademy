export class CreateTrainingModel {
  title: string;
  description: string;
  city: string;
  address: string;
  maxPetCount: number;
  genreId: number;
  userId: number;
  price: number;

  constructor(
    title: string,
    description: string,
    city: string,
    address: string,
    maxPetCount: number,
    genreId: number,
    userId: number,
    price: number
  ) {
    this.title = title;
    this.description = description;
    this.city = city;
    this.address = address;
    this.maxPetCount = maxPetCount;
    this.genreId = genreId;
    this.userId = userId;
    this.price = price;
  }
}
