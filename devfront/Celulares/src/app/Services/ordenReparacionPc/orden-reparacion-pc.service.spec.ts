import { TestBed } from '@angular/core/testing';

import { OrdenReparacionPcService } from './orden-reparacion-pc.service';

describe('OrdenReparacionPcService', () => {
  let service: OrdenReparacionPcService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(OrdenReparacionPcService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
