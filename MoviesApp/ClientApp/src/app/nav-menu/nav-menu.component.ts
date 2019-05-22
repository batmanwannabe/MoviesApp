import { Component } from '@angular/core';
import { AddNewMovieComponent } from '../add-new-movie/add-new-movie.component';
import { NgbModal } from '@ng-bootstrap/ng-bootstrap';
import { AddNewActorComponent } from '../add-new-actor/add-new-actor.component';
import { AddNewProducerComponent } from '../add-new-producer/add-new-producer.component';

@Component({
  selector: 'app-nav-menu',
  templateUrl: './nav-menu.component.html',
  styleUrls: ['./nav-menu.component.css']
})
export class NavMenuComponent {

  constructor(
    private modalService: NgbModal
  ) {}
  isExpanded = false;

  collapse() {
    this.isExpanded = false;
  }

  toggle() {
    this.isExpanded = !this.isExpanded;
  }

  openNewMovie() {
    const modalRef = this.modalService.open(AddNewMovieComponent);

    modalRef.result.then((result) => {
      console.log(result);
    }).catch((error) => {
      console.log(error);
    });
  }

  openNewActor() {
    const modalRef = this.modalService.open(AddNewActorComponent);

    modalRef.result.then((result) => {
      console.log(result);
    }).catch((error) => {
      console.log(error);
    });
  }

  openNewProducer() {
    const modalRef = this.modalService.open(AddNewProducerComponent);

    modalRef.result.then((result) => {
      console.log(result);
    }).catch((error) => {
      console.log(error);
    });
  }
}
