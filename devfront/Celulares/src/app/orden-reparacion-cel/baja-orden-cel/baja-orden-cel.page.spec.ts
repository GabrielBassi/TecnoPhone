import { async, ComponentFixture, TestBed } from '@angular/core/testing';
import { IonicModule } from '@ionic/angular';

import { BajaOrdenCelPage } from './baja-orden-cel.page';

describe('BajaOrdenCelPage', () => {
  let component: BajaOrdenCelPage;
  let fixture: ComponentFixture<BajaOrdenCelPage>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ BajaOrdenCelPage ],
      imports: [IonicModule.forRoot()]
    }).compileComponents();

    fixture = TestBed.createComponent(BajaOrdenCelPage);
    component = fixture.componentInstance;
    fixture.detectChanges();
  }));

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
