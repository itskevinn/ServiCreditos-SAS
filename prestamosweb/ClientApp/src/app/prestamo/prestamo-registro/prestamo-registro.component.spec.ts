import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { PrestamoRegistroComponent } from './prestamo-registro.component';

describe('PrestamoRegistroComponent', () => {
  let component: PrestamoRegistroComponent;
  let fixture: ComponentFixture<PrestamoRegistroComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ PrestamoRegistroComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(PrestamoRegistroComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
