import { Component } from '@angular/core';
import { NgbModal } from '@ng-bootstrap/ng-bootstrap'; 
import { AddNewMovieComponent } from './add-new-movie/add-new-movie.component';


@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent {
  title = 'DeltaX Movies!';

  constructor(
    private modalService: NgbModal
  ) { }

  openFormModal() {
    const modalRef = this.modalService.open(AddNewMovieComponent);
    modalRef.componentInstance.id = 10; // should be the id
    modalRef.result.then((result) => {
      console.log(result);
    }).catch((error) => {
      console.log(error);
    });
  }
}
