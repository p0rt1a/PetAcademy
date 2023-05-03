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

@NgModule({
  declarations: [AppComponent, TrainingsComponent, TrainingDetailComponent, CreateEnrollmentComponent],
  imports: [
    BrowserModule,
    AppRoutingModule,
    HttpClientModule,
    RouterModule.forRoot(appRoutes),
  ],
  providers: [],
  bootstrap: [AppComponent],
})
export class AppModule {}
