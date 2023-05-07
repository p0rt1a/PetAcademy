export class TrainingCommentViewModel {
  userId: number;
  body: string;
  user: string;
  date: string;

  constructor(userId: number, body: string, user: string, date: string) {
    this.userId = userId;
    this.body = body;
    this.user = user;
    this.date = date;
  }
}
