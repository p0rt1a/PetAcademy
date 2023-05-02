export class TrainingModel {
  id: number;
  title: string;
  description: string;
  city: string;
  genre: string;
  price: number;

  constructor(
    id: number,
    title: string,
    description: string,
    city: string,
    genre: string,
    price: number
  ) {
    this.id = id;
    this.title = title;
    this.description = description;
    this.city = city;
    this.genre = genre;
    this.price = price;
  }
}
