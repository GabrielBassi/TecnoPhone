import { async, ComponentFixture, TestBed } from '@angular/core/testing';
import { IonicModule } from '@ionic/angular';

import { BajaOrdenPcPage } from './baja-orden-pc.page';

describe('BajaOrdenPcPage', () => {
  let component: BajaOrdenPcPage;
  let fixture: ComponentFixture<BajaOrdenPcPage>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ BajaOrdenPcPage ],
      imports: [IonicModule.forRoot()]
    }).compileComponents();

    fixture = TestBed.createComponent(BajaOrdenPcPage);
    component = fixture.componentInstance;
    fixture.detectChanges();
  }));

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
