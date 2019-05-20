import { Component, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Component({
  selector: 'app-all-movies',
  templateUrl: './movies-list.component.html'
})
export class MoviesListComponent {
  public movies: Movies[];

  constructor(http: HttpClient, @Inject('BASE_URL') baseUrl: string) {
    http.get<Movies[]>(baseUrl + 'api/Movies/GetAllMovies').subscribe(result => {
      this.movies = result;
    }, error => console.error(error));
  }
}

interface Movies {
  movieName: string;
  movieId: number;
  moviePoster: string;
  movieYear: Date;
  producerName: string;
  producerId: number;
  actors: Actor[];
}
interface Actor {
  actorId: number;
  actorName: string;
  actorSex: string;
  actorBio: string;
  actorDOB: Date;
}
