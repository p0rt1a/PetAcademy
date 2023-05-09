import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { HttpClientModule } from '@angular/common/http';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { TrainingsComponent } from './components/trainings/trainings.component';
import { TrainingDetailComponent } from './components/trainings/training-detail/training-detail.component';
import { RouterModule } from '@angular/router';
import { appRoutes } from 'src/routes';
import { CreateEnrollmentComponent } from './components/enrollments/create-enrollment/create-enrollment.component';
import { NavbarComponent } from './components/navbar/navbar.component';
import { RegisterComponent } from './components/auth/register/register.component';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { LoginComponent } from './components/auth/login/login.component';
import { ProfileComponent } from './components/profile/profile.component';
import { MyTrainingsComponent } from './components/trainings/my-trainings/my-trainings.component';
import { UpdateTrainingComponent } from './components/trainings/update-training/update-training.component';
import { CreateTrainingComponent } from './components/trainings/create-training/create-training.component';
import { ViewTrainingComponent } from './components/trainings/view-training/view-training.component';

@NgModule({
  declarations: [
    AppComponent,
    TrainingsComponent,
    TrainingDetailComponent,
    CreateEnrollmentComponent,
    NavbarComponent,
    RegisterComponent,
    LoginComponent,
    ProfileComponent,
    MyTrainingsComponent,
    UpdateTrainingComponent,
    CreateTrainingComponent,
    ViewTrainingComponent,
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    HttpClientModule,
    RouterModule.forRoot(appRoutes),
    FormsModule,
    ReactiveFormsModule,
  ],
  providers: [],
  bootstrap: [AppComponent],
})
export class AppModule {}
