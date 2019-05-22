import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { AddNewProducerComponent } from './add-new-producer.component';

describe('AddNewProducerComponent', () => {
  let component: AddNewProducerComponent;
  let fixture: ComponentFixture<AddNewProducerComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ AddNewProducerComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(AddNewProducerComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
