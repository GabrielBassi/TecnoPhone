import { async, ComponentFixture, TestBed } from '@angular/core/testing';
import { IonicModule } from '@ionic/angular';

import { OrdenReparacionCelPage } from './orden-reparacion-cel.page';

describe('OrdenReparacionCelPage', () => {
  let component: OrdenReparacionCelPage;
  let fixture: ComponentFixture<OrdenReparacionCelPage>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ OrdenReparacionCelPage ],
      imports: [IonicModule.forRoot()]
    }).compileComponents();

    fixture = TestBed.createComponent(OrdenReparacionCelPage);
    component = fixture.componentInstance;
    fixture.detectChanges();
  }));

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
