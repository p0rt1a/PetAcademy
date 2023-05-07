export class UserPetViewModel {
  id: number;
  name: string;
  genre: string;

  constructor(id: number, name: string, genre: string) {
    this.id = id;
    this.name = name;
    this.genre = genre;
  }
}
