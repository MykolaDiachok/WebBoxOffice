import { TestBed } from '@angular/core/testing';

import { DataBoxOfficeService } from './data-box-office.service';

describe('DataBoxOfficeService', () => {
  beforeEach(() => TestBed.configureTestingModule({}));

  it('should be created', () => {
    const service: DataBoxOfficeService = TestBed.get(DataBoxOfficeService);
    expect(service).toBeTruthy();
  });
});
