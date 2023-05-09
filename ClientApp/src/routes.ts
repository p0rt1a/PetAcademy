import { Routes } from '@angular/router';
import { TrainingDetailComponent } from './app/components/trainings/training-detail/training-detail.component';
import { TrainingsComponent } from './app/components/trainings/trainings.component';
import { CreateEnrollmentComponent } from './app/components/enrollments/create-enrollment/create-enrollment.component';
import { RegisterComponent } from './app/components/auth/register/register.component';
import { LoginComponent } from './app/components/auth/login/login.component';
import { ProfileComponent } from './app/components/profile/profile.component';
import { MyTrainingsComponent } from './app/components/trainings/my-trainings/my-trainings.component';
import { UpdateTrainingComponent } from './app/components/trainings/update-training/update-training.component';
import { CreateTrainingComponent } from './app/components/trainings/create-training/create-training.component';
import { ViewTrainingComponent } from './app/components/trainings/view-training/view-training.component';

export const appRoutes: Routes = [
  { path: 'trainings', component: TrainingsComponent },
  { path: 'training-detail', component: TrainingDetailComponent },
  { path: 'create-enrollment', component: CreateEnrollmentComponent },
  { path: 'register', component: RegisterComponent },
  { path: 'login', component: LoginComponent },
  { path: 'profile', component: ProfileComponent },
  { path: 'my-trainings', component: MyTrainingsComponent },
  { path: 'update-training', component: UpdateTrainingComponent },
  { path: 'create-training', component: CreateTrainingComponent },
  { path: 'view-training', component: ViewTrainingComponent },
];
