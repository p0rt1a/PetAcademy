import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { CreateCommentModel } from 'src/app/models/CreateCommentModel';
import { TrainingCommentViewModel } from 'src/app/models/TrainingCommentViewModel';
import { TrainingDetailModel } from 'src/app/models/TrainingDetailModel';
import { AuthService } from 'src/app/services/auth.service';
import { CommentsService } from 'src/app/services/comments.service';
import { TrainingsService } from 'src/app/services/trainings.service';

declare let alertify: any;

@Component({
  selector: 'app-training-detail',
  templateUrl: './training-detail.component.html',
  styleUrls: ['./training-detail.component.css'],
})
export class TrainingDetailComponent implements OnInit {
  selectedTrainingId: number = 0;
  training: TrainingDetailModel = new TrainingDetailModel(
    '',
    '',
    '',
    '',
    '',
    0,
    '',
    '',
    0
  );
  comments: TrainingCommentViewModel[] = [];
  isUserHaveComment: boolean = false;
  createCommentModel: CreateCommentModel = new CreateCommentModel(0, '', 0);

  constructor(
    private trainingsService: TrainingsService,
    private authService: AuthService,
    private commentsService: CommentsService,
    private router: Router
  ) {}

  ngOnInit(): void {
    this.trainingsService.selectedTrainingId.subscribe((response) => {
      this.selectedTrainingId = response;
    });

    this.getTrainingDetail();

    this.trainingsService
      .getTrainingComments(this.selectedTrainingId)
      .subscribe((response) => {
        this.comments = response;

        response.forEach((item) => {
          if (item.userId == this.authService.getUserId()) {
            this.isUserHaveComment = true;
          }
        });
      });
  }

  getTrainingDetail() {
    this.trainingsService
      .getTrainingDetail(this.selectedTrainingId)
      .subscribe((response) => {
        this.training = response;
      });
  }

  createEnrollment() {
    this.router.navigate(['/create-enrollment']);
  }

  createComment() {
    this.createCommentModel.trainingId = this.selectedTrainingId;
    this.createCommentModel.userId = this.authService.getUserId();

    console.log(this.createCommentModel);

    this.commentsService.createComment(this.createCommentModel).subscribe(
      (response) => {
        if (response.status == 200) {
          alertify.success('Yorum başarıyla eklendi.');
          this.router.routeReuseStrategy.shouldReuseRoute = () => false;
          this.router.onSameUrlNavigation = 'reload';
          this.router.navigate(['/training-detail']);
        }
      },
      (error) => {
        alertify.error(error.error.error);
      }
    );
  }
}
