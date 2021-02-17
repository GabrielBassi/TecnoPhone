import { async, ComponentFixture, TestBed } from '@angular/core/testing';
import { IonicModule } from '@ionic/angular';

import { ModificarOrdenPcPage } from './modificar-orden-pc.page';

describe('ModificarOrdenPcPage', () => {
  let component: ModificarOrdenPcPage;
  let fixture: ComponentFixture<ModificarOrdenPcPage>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ ModificarOrdenPcPage ],
      imports: [IonicModule.forRoot()]
    }).compileComponents();

    fixture = TestBed.createComponent(ModificarOrdenPcPage);
    component = fixture.componentInstance;
    fixture.detectChanges();
  }));

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
