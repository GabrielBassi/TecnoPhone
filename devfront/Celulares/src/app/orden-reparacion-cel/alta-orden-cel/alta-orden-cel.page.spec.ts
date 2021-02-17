import { async, ComponentFixture, TestBed } from '@angular/core/testing';
import { IonicModule } from '@ionic/angular';

import { AltaOrdenCelPage } from './alta-orden-cel.page';

describe('AltaOrdenCelPage', () => {
  let component: AltaOrdenCelPage;
  let fixture: ComponentFixture<AltaOrdenCelPage>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ AltaOrdenCelPage ],
      imports: [IonicModule.forRoot()]
    }).compileComponents();

    fixture = TestBed.createComponent(AltaOrdenCelPage);
    component = fixture.componentInstance;
    fixture.detectChanges();
  }));

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
