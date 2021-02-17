import { TestBed } from '@angular/core/testing';

import { OrdenReparacionCelService } from './orden-reparacion-cel.service';

describe('OrdenReparacionCelService', () => {
  let service: OrdenReparacionCelService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(OrdenReparacionCelService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
