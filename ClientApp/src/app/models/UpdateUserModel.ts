export class UpdateUserModel {
  image: string;
  email: string;

  constructor(image: string, email: string) {
    this.image = image;
    this.email = email;
  }
}
