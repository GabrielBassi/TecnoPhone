import { async, ComponentFixture, TestBed } from '@angular/core/testing';
import { IonicModule } from '@ionic/angular';

import { AltaOrdenPcPage } from './alta-orden-pc.page';

describe('AltaOrdenPcPage', () => {
  let component: AltaOrdenPcPage;
  let fixture: ComponentFixture<AltaOrdenPcPage>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ AltaOrdenPcPage ],
      imports: [IonicModule.forRoot()]
    }).compileComponents();

    fixture = TestBed.createComponent(AltaOrdenPcPage);
    component = fixture.componentInstance;
    fixture.detectChanges();
  }));

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
