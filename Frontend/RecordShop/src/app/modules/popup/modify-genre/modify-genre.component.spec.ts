import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { ModifyGenreComponent } from './modify-genre.component';

describe('ModifyGenreComponent', () => {
  let component: ModifyGenreComponent;
  let fixture: ComponentFixture<ModifyGenreComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ ModifyGenreComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(ModifyGenreComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
