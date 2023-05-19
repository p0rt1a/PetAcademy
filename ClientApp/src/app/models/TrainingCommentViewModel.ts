export class TrainingCommentViewModel {
  userId: number;
  body: string;
  user: string;
  userImage: string;
  date: string;

  constructor(
    userId: number,
    body: string,
    user: string,
    userImage: string,
    date: string
  ) {
    this.userId = userId;
    this.body = body;
    this.user = user;
    this.userImage = userImage;
    this.date = date;
  }
}
