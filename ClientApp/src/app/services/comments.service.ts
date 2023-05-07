import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { CreateCommentModel } from '../models/CreateCommentModel';

@Injectable({
  providedIn: 'root',
})
export class CommentsService {
  private url: string = 'https://localhost:5001/comments';

  constructor(private http: HttpClient) {}

  createComment(model: CreateCommentModel) {
    return this.http.post(this.url, model, { observe: 'response' });
  }
}
