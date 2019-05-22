import { Component, OnInit, Input, Inject } from '@angular/core';
import { FormGroup, FormBuilder } from '@angular/forms';
import { NgbActiveModal } from '@ng-bootstrap/ng-bootstrap';
import { HttpClient } from '@angular/common/http';

@Component({
  selector: 'app-add-new-producer',
  templateUrl: './add-new-producer.component.html',
  styleUrls: ['./add-new-producer.component.css']
})
export class AddNewProducerComponent implements OnInit {

  ngOnInit(): void {

  }
  @Input() id: number;
  url: string;
  producerDob: Date;

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
      producerName: '',
      producerBio: '',
      producerDob: '',
      Dob: '',
      producerSex: ''
    });
  }
  private submitForm() {
    this.producerDob = new Date(1994, 2, 1);
    this.myForm.value.producerDob = this.producerDob;
    this.httpClient.post<any>(this.url + 'api/movies/AddNewproducer', this.myForm.value).subscribe(
      (res) => console.log(res),
      (err) => console.log(err)
    );
    this.activeModal.close(this.myForm.value);
  }

  closeModal() {
    this.activeModal.close('Modal Closed');
  }

}
