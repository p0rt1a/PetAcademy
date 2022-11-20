import { Routes } from '@angular/router';
import { HomeComponent } from './home/home.component';
import { LoginComponent } from './login/login.component';
import { NotfoundComponent } from './notfound/notfound.component';
import { RegisterComponent } from './register/register.component';
import { TrainersComponent } from './trainers/trainers.component';
import { TrainingsComponent } from './trainings/trainings.component';

export const appRoutes: Routes = [
  { path: '', component: HomeComponent },
  { path: 'home', component: HomeComponent },
  { path: 'register', component: RegisterComponent },
  { path: 'login', component: LoginComponent },
  { path: 'trainings', component: TrainingsComponent },
  { path: 'trainers', component: TrainersComponent },
  { path: '**', component: NotfoundComponent },
];
