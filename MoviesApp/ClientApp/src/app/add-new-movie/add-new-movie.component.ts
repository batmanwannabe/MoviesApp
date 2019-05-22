import { Component, OnInit, Input, HostListener, Inject } from '@angular/core';
import { NgbActiveModal } from '@ng-bootstrap/ng-bootstrap';
import { FormGroup, FormBuilder, FormControl } from '@angular/forms';
import { saveAs } from 'file-saver';
import { HttpRequest, HttpClient, HttpEventType } from '@angular/common/http';



@Component({
  selector: 'app-add-new-movie',
  templateUrl: './add-new-movie.component.html',
  styleUrls: ['./add-new-movie.component.css']
})
export class AddNewMovieComponent implements OnInit {


    ngOnInit(): void {
        
    }
  @Input() id: number;
  url: string;
  filePath: string;
  movieYear: Date;
  

  myForm: FormGroup;
  constructor(
    public activeModal: NgbActiveModal,
    private formBuilder: FormBuilder,
    private http: HttpClient,
    @Inject('BASE_URL') baseUrl: string
  ) {
    this.url = baseUrl;

    this.createForm();
  }
  private createForm() {
    this.myForm = this.formBuilder.group({
      movieName: '',
      moviePlot: '',
      produerId: '',
      movieYear: '',
      moviePoster: '',

      image: new FormData()
    });
  }

  private file: File | null = null;

  @HostListener('change', ['$event.target.files']) emitFiles(event: FileList) {
    const file = event && event.item(0);
    this.file = file;
    //this.saveToFileSystem(this.file);
    const formData = new FormData();
    formData.append(this.file.name, this.file);

    const uploadReq = new HttpRequest('POST', this.url + 'api/movies/UploadFile', formData, {
      reportProgress: true,
    });

    this.http.request(uploadReq).subscribe(event => {
      if (event.type === HttpEventType.Response)
        this.filePath = event.body.toString();
    });  

  }

  private submitForm() {
    this.movieYear = new Date(1994, 2, 1);
    this.myForm.value.movieYear = this.movieYear;
    this.http.post<any>(this.url + 'api/movies/AddNewMovie', this.myForm.value).subscribe(
      (res) => console.log(res),
      (err) => console.log(err)
    );
    this.activeModal.close(this.myForm.value);
    
  
  }

  closeModal() {
    this.activeModal.close('Modal Closed');
  }

  private saveToFileSystem(response) {
    const filename = this.file.name;
    const blob = new Blob([response._body], { type: this.file.type });
    saveAs(blob, filename);
  }
  
  

}
