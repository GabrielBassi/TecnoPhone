import { async, ComponentFixture, TestBed } from '@angular/core/testing';
import { IonicModule } from '@ionic/angular';

import { ModificarOrdenCelPage } from './modificar-orden-cel.page';

describe('ModificarOrdenCelPage', () => {
  let component: ModificarOrdenCelPage;
  let fixture: ComponentFixture<ModificarOrdenCelPage>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ ModificarOrdenCelPage ],
      imports: [IonicModule.forRoot()]
    }).compileComponents();

    fixture = TestBed.createComponent(ModificarOrdenCelPage);
    component = fixture.componentInstance;
    fixture.detectChanges();
  }));

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
