import { async, ComponentFixture, TestBed } from '@angular/core/testing';
import { IonicModule } from '@ionic/angular';

import { BajaClientePage } from './baja-cliente.page';

describe('BajaClientePage', () => {
  let component: BajaClientePage;
  let fixture: ComponentFixture<BajaClientePage>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ BajaClientePage ],
      imports: [IonicModule.forRoot()]
    }).compileComponents();

    fixture = TestBed.createComponent(BajaClientePage);
    component = fixture.componentInstance;
    fixture.detectChanges();
  }));

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
