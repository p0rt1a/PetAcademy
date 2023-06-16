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
import { AuthGuard } from './app/guards/auth-guard';
import { CertificateComponent } from './app/components/certificate/certificate.component';
import { HomeComponent } from './app/components/home/home.component';

export const appRoutes: Routes = [
  { path: 'home', component: HomeComponent, pathMatch: 'full' },
  { path: 'trainings', component: TrainingsComponent, pathMatch: 'full' },
  {
    path: 'training-detail',
    component: TrainingDetailComponent,
    pathMatch: 'full',
  },
  {
    path: 'create-enrollment',
    component: CreateEnrollmentComponent,
    canActivate: [AuthGuard],
    pathMatch: 'full',
  },
  { path: 'register', component: RegisterComponent, pathMatch: 'full' },
  { path: 'login', component: LoginComponent, pathMatch: 'full' },
  {
    path: 'profile',
    component: ProfileComponent,
    canActivate: [AuthGuard],
    pathMatch: 'full',
  },
  {
    path: 'my-trainings',
    component: MyTrainingsComponent,
    canActivate: [AuthGuard],
    pathMatch: 'full',
  },
  {
    path: 'update-training',
    component: UpdateTrainingComponent,
    canActivate: [AuthGuard],
    pathMatch: 'full',
  },
  {
    path: 'create-training',
    component: CreateTrainingComponent,
    canActivate: [AuthGuard],
    pathMatch: 'full',
  },
  {
    path: 'view-training',
    component: ViewTrainingComponent,
    canActivate: [AuthGuard],
    pathMatch: 'full',
  },
  {
    path: 'certificate',
    component: CertificateComponent,
    canActivate: [AuthGuard],
    pathMatch: 'full',
  },
];
