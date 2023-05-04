export class PetViewModel {
  id: number;
  name: string;
  age: number;
  genre: string;

  constructor(id: number, name: string, age: number, genre: string) {
    this.id = id;
    this.name = name;
    this.age = age;
    this.genre = genre;
  }
}
