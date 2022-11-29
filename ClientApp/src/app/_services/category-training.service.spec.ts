import { TestBed } from '@angular/core/testing';

import { CategoryTrainingService } from './category-training.service';

describe('CategoryTrainingService', () => {
  let service: CategoryTrainingService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(CategoryTrainingService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
