import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { AddNewActorComponent } from './add-new-actor.component';

describe('AddNewActorComponent', () => {
  let component: AddNewActorComponent;
  let fixture: ComponentFixture<AddNewActorComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ AddNewActorComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(AddNewActorComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
