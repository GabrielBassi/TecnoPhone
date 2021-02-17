import { async, ComponentFixture, TestBed } from '@angular/core/testing';
import { IonicModule } from '@ionic/angular';

import { ConsultarOrdenCelPage } from './consultar-orden-cel.page';

describe('ConsultarOrdenCelPage', () => {
  let component: ConsultarOrdenCelPage;
  let fixture: ComponentFixture<ConsultarOrdenCelPage>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ ConsultarOrdenCelPage ],
      imports: [IonicModule.forRoot()]
    }).compileComponents();

    fixture = TestBed.createComponent(ConsultarOrdenCelPage);
    component = fixture.componentInstance;
    fixture.detectChanges();
  }));

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
