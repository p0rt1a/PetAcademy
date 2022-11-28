import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';

import { HttpClientModule } from '@angular/common/http';
import { CategoriesComponent } from './categories/categories.component';
import { TrainingsComponent } from './trainings/trainings.component';
import { RegisterComponent } from './register/register.component';
import { LoginComponent } from './login/login.component';
import { HomeComponent } from './home/home.component';
import { NotfoundComponent } from './notfound/notfound.component';
import { RouterModule } from '@angular/router';
import { appRoutes } from './routes';
import { NavbarComponent } from './navbar/navbar.component';
import { TrainersComponent } from './trainers/trainers.component';
import { FormsModule } from '@angular/forms';
import { UpdateTrainingComponent } from './update-training/update-training.component';
import { AddTrainingComponent } from './add-training/add-training.component';
import { TrainingCategoryComponent } from './training-category/training-category.component';

@NgModule({
  declarations: [
    AppComponent,
    CategoriesComponent,
    TrainingsComponent,
    RegisterComponent,
    LoginComponent,
    HomeComponent,
    NotfoundComponent,
    NavbarComponent,
    TrainersComponent,
    UpdateTrainingComponent,
    AddTrainingComponent,
    TrainingCategoryComponent,
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    HttpClientModule,
    FormsModule,
    RouterModule.forRoot(appRoutes),
  ],
  providers: [],
  bootstrap: [AppComponent],
})
export class AppModule {}
