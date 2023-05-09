export class TrainingPetViewModel {
  name: string;
  age: number;
  genre: string;
  userEmail: string;

  constructor(name: string, age: number, genre: string, userEmail: string) {
    this.name = name;
    this.age = age;
    this.genre = genre;
    this.userEmail = userEmail;
  }
}
