import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { ModifySongComponent } from './modify-song.component';

describe('ModifySongComponent', () => {
  let component: ModifySongComponent;
  let fixture: ComponentFixture<ModifySongComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ ModifySongComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(ModifySongComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
