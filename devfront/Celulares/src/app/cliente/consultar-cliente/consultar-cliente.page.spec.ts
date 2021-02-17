import { async, ComponentFixture, TestBed } from '@angular/core/testing';
import { IonicModule } from '@ionic/angular';

import { ConsultarClientePage } from './consultar-cliente.page';

describe('ConsultarClientePage', () => {
  let component: ConsultarClientePage;
  let fixture: ComponentFixture<ConsultarClientePage>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ ConsultarClientePage ],
      imports: [IonicModule.forRoot()]
    }).compileComponents();

    fixture = TestBed.createComponent(ConsultarClientePage);
    component = fixture.componentInstance;
    fixture.detectChanges();
  }));

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
