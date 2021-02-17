import { async, ComponentFixture, TestBed } from '@angular/core/testing';
import { IonicModule } from '@ionic/angular';

import { ConsultarOrdenPcPage } from './consultar-orden-pc.page';

describe('ConsultarOrdenPcPage', () => {
  let component: ConsultarOrdenPcPage;
  let fixture: ComponentFixture<ConsultarOrdenPcPage>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ ConsultarOrdenPcPage ],
      imports: [IonicModule.forRoot()]
    }).compileComponents();

    fixture = TestBed.createComponent(ConsultarOrdenPcPage);
    component = fixture.componentInstance;
    fixture.detectChanges();
  }));

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
