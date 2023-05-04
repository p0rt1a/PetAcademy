export class CreatePetModel {
  name: string;
  age: number;
  genreId: number;
  userId: number;

  constructor(name: string, age: number, genreId: number, userId: number) {
    this.name = name;
    this.age = age;
    this.genreId = genreId;
    this.userId = userId;
  }
}
