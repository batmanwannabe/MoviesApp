import { Component, OnInit, Input, Inject } from '@angular/core';
import { FormGroup, FormBuilder } from '@angular/forms';
import { NgbActiveModal } from '@ng-bootstrap/ng-bootstrap';
import { HttpClient } from '@angular/common/http';

@Component({
  selector: 'app-add-new-actor',
  templateUrl: './add-new-actor.component.html',
  styleUrls: ['./add-new-actor.component.css']
})
export class AddNewActorComponent implements OnInit {

  ngOnInit(): void {

  }
  @Input() id: number;
  url: string;
  actorDob: Date;

  myForm: FormGroup;
  constructor(
    public activeModal: NgbActiveModal,
    private formBuilder: FormBuilder,
    private httpClient: HttpClient,
    @Inject('BASE_URL') baseUrl: string
  ) {
    this.url = baseUrl;
    this.createForm();
  }
  private createForm() {
    this.myForm = this.formBuilder.group({
      actorName: '',
      actorBio: '',
      actorDob: '',
      Dob: '',
      actorSex: ''
    });
  }
  private submitForm() {
    this.actorDob = new Date(1994, 2, 1);
    this.myForm.value.actorDob = this.actorDob;
    this.httpClient.post<any>(this.url + 'api/movies/AddNewActor', this.myForm.value).subscribe(
      (res) => console.log(res),
      (err) => console.log(err)
    );
    this.activeModal.close(this.myForm.value);
  }

  closeModal() {
    this.activeModal.close('Modal Closed');
  }


}
