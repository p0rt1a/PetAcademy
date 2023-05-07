export class CreateCommentModel {
  userId: number;
  body: string;
  trainingId: number;

  constructor(userId: number, body: string, trainingId: number) {
    this.userId = userId;
    this.body = body;
    this.trainingId = trainingId;
  }
}
