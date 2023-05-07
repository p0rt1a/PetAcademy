export class UpdatePetModel {
  userId: number;
  name: string;
  age: number;

  constructor(userId: number, name: string, age: number) {
    this.userId = userId;
    this.name = name;
    this.age = age;
  }
}
