import { Routes } from '@angular/router';
import { TrainingDetailComponent } from './app/components/trainings/training-detail/training-detail.component';
import { TrainingsComponent } from './app/components/trainings/trainings.component';
import { CreateEnrollmentComponent } from './app/components/enrollments/create-enrollment/create-enrollment.component';
import { RegisterComponent } from './app/components/auth/register/register.component';

export const appRoutes: Routes = [
  { path: '', component: TrainingsComponent },
  { path: 'training-detail', component: TrainingDetailComponent },
  { path: 'create-enrollment', component: CreateEnrollmentComponent },
  { path: 'register', component: RegisterComponent },
];
