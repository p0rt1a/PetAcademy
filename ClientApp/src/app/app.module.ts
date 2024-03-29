import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { HTTP_INTERCEPTORS, HttpClientModule } from '@angular/common/http';

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
import { JwtModule } from '@auth0/angular-jwt';
import { AuthGuard } from './guards/auth-guard';
import { TokenIntercaptor } from './services/token.intercaptor';
import { CertificateComponent } from './components/certificate/certificate.component';
import { HomeComponent } from './components/home/home.component';

export function tokenGetter() {
  return localStorage.getItem('token');
}

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
    CertificateComponent,
    HomeComponent,
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    HttpClientModule,
    JwtModule.forRoot({
      config: {
        tokenGetter: tokenGetter,
        allowedDomains: ['localhost:5000'],
        disallowedRoutes: ['locahost:5000/api/auth'],
      },
    }),
    RouterModule.forRoot(appRoutes, { onSameUrlNavigation: 'reload' }),
    FormsModule,
    ReactiveFormsModule,
  ],
  providers: [
    {
      provide: HTTP_INTERCEPTORS,
      useClass: TokenIntercaptor,
      multi: true,
    },
  ],
  bootstrap: [AppComponent],
})
export class AppModule {}
