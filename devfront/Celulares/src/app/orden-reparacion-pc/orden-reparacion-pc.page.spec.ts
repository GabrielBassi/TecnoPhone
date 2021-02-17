import { async, ComponentFixture, TestBed } from '@angular/core/testing';
import { IonicModule } from '@ionic/angular';

import { OrdenReparacionPcPage } from './orden-reparacion-pc.page';

describe('OrdenReparacionPcPage', () => {
  let component: OrdenReparacionPcPage;
  let fixture: ComponentFixture<OrdenReparacionPcPage>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ OrdenReparacionPcPage ],
      imports: [IonicModule.forRoot()]
    }).compileComponents();

    fixture = TestBed.createComponent(OrdenReparacionPcPage);
    component = fixture.componentInstance;
    fixture.detectChanges();
  }));

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
