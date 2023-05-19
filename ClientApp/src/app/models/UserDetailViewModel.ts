export class UserDetailViewModel {
  image: string;
  name: string;
  surname: string;
  email: string;

  constructor(image: string, name: string, surname: string, email: string) {
    this.image = image;
    this.name = name;
    this.surname = surname;
    this.email = email;
  }
}
