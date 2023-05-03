import { Routes } from '@angular/router';
import { TrainingDetailComponent } from './app/components/trainings/training-detail/training-detail.component';
import { TrainingsComponent } from './app/components/trainings/trainings.component';

export const appRoutes: Routes = [
  { path: '', component: TrainingsComponent },
  { path: 'training-detail', component: TrainingDetailComponent },
];
