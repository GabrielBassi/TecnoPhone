import { async, ComponentFixture, TestBed } from '@angular/core/testing';
import { IonicModule } from '@ionic/angular';

import { ModificarClientePage } from './modificar-cliente.page';

describe('ModificarClientePage', () => {
  let component: ModificarClientePage;
  let fixture: ComponentFixture<ModificarClientePage>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ ModificarClientePage ],
      imports: [IonicModule.forRoot()]
    }).compileComponents();

    fixture = TestBed.createComponent(ModificarClientePage);
    component = fixture.componentInstance;
    fixture.detectChanges();
  }));

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
