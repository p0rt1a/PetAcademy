export class TrainingDetailModel {
  title: string;
  description: string;
  city: string;
  address: string;
  genre: string;
  price: number;
  trainerName: string;
  trainerEmail: string;
  maxPetCount: number;

  constructor(
    title: string,
    description: string,
    city: string,
    address: string,
    genre: string,
    price: number,
    trainerName: string,
    trainerEmail: string,
    maxPetCount: number
  ) {
    this.title = title;
    this.description = description;
    this.city = city;
    this.address = address;
    this.genre = genre;
    this.price = price;
    this.trainerName = trainerName;
    this.trainerEmail = trainerEmail;
    this.maxPetCount = maxPetCount;
  }
}
