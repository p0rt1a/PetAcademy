import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { CreateCertificateModel } from 'src/app/models/CreateCertificateModel';
import { TrainingDetailModel } from 'src/app/models/TrainingDetailModel';
import { TrainingPetViewModel } from 'src/app/models/TrainingPetViewModel';
import { CertificateService } from 'src/app/services/certificate.service';
import { EnrollmentsService } from 'src/app/services/enrollments.service';
import { TrainingsService } from 'src/app/services/trainings.service';

declare let alertify: any;

@Component({
  selector: 'app-view-training',
  templateUrl: './view-training.component.html',
  styleUrls: ['./view-training.component.css'],
})
export class ViewTrainingComponent implements OnInit {
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
  pets: TrainingPetViewModel[] = [];

  constructor(
    private trainingsService: TrainingsService,
    private certificatesService: CertificateService,
    private router: Router,
    private enrollmentsService: EnrollmentsService
  ) {}

  ngOnInit(): void {
    this.trainingsService.selectedTrainingId.subscribe((res) => {
      this.selectedTrainingId = res;
    });

    this.trainingsService
      .getTrainingPets(this.selectedTrainingId)
      .subscribe((response) => {
        this.pets = response;
      });

    this.trainingsService
      .getTrainingDetail(this.selectedTrainingId)
      .subscribe((response) => {
        this.training = response;
      });
  }

  graduate(petId: number) {
    let model: CreateCertificateModel = new CreateCertificateModel(
      petId,
      this.selectedTrainingId
    );

    alertify.confirm(
      'Mezuniyet işlemini onaylıyor musunuz?',
      () => {
        this.certificatesService.createCertificate(model).subscribe(
          (response) => {
            if (response.status == 200) {
              alertify.success('Mezun etme işlemi başarılı!');
              this.router.navigate(['my-trainings']);
            }
          },
          (error) => {
            alertify.error(error.error.error);
          }
        );
      },
      () => {
        alertify.error('Cancel');
      }
    );
  }

  deleteEnrollment(petId: number) {
    alertify.confirm(
      'Evcil hayvan, eğitimden silinecektir. Onaylıyor musunuz?',
      () => {
        this.enrollmentsService
          .deleteEnrollment(petId, this.selectedTrainingId)
          .subscribe(
            (response) => {
              if (response.status == 200) {
                alertify.success('Kayıt başarıyla silindi');
                this.router.navigate(['my-trainings']);
              }
            },
            (error) => {
              alertify.error(error.error.error);
            }
          );
      },
      () => {
        alertify.error('Cancel');
      }
    );
  }
}
