import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';
import { RouterModule } from '@angular/router';

import { AppComponent } from './app.component';
import { NavMenuComponent } from './nav-menu/nav-menu.component';
import { HomeComponent } from './home/home.component';
import { CounterComponent } from './counter/counter.component';
import { FetchDataComponent } from './fetch-data/fetch-data.component';
import { MoviesListComponent } from './list-movies/movies-list.component';
import { NgbModule } from '@ng-bootstrap/ng-bootstrap';
import { AddNewMovieComponent } from './add-new-movie/add-new-movie.component';
import { ReactiveFormsModule } from '@angular/forms';
import { AddNewActorComponent } from './add-new-actor/add-new-actor.component';
import { AddNewProducerComponent } from './add-new-producer/add-new-producer.component';

@NgModule({
  declarations: [
    AppComponent,
    NavMenuComponent,
    HomeComponent,
    CounterComponent,
    FetchDataComponent,
    MoviesListComponent,
    AddNewMovieComponent,
    AddNewActorComponent,
    AddNewProducerComponent
  ],
  imports: [
    BrowserModule.withServerTransition({ appId: 'ng-cli-universal' }),
    HttpClientModule,
    FormsModule,
    RouterModule.forRoot([
      { path: '', component: HomeComponent, pathMatch: 'full' },
      { path: 'counter', component: CounterComponent },
      { path: 'fetch-data', component: FetchDataComponent },
      { path: 'list-movies', component: MoviesListComponent }
    ]),
    NgbModule.forRoot(),
    ReactiveFormsModule
  ],
  providers: [],
  bootstrap: [AppComponent],
  entryComponents: [
    AddNewMovieComponent,
    AddNewActorComponent,
    AddNewProducerComponent
  ]
})
export class AppModule { }
