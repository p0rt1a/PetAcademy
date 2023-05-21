export class TrainingPetViewModel {
  petId: number;
  name: string;
  age: number;
  genre: string;
  userEmail: string;

  constructor(
    petId: number,
    name: string,
    age: number,
    genre: string,
    userEmail: string
  ) {
    this.petId = petId;
    this.name = name;
    this.age = age;
    this.genre = genre;
    this.userEmail = userEmail;
  }
}
