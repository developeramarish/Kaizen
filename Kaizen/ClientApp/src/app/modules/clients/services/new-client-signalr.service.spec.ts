import { HttpClientTestingModule } from '@angular/common/http/testing';
import { TestBed } from '@angular/core/testing';
import { NewClientSignalrService } from './new-client-signalr.service';

describe('NewClientSignalrService', () => {
  let service: NewClientSignalrService;

  beforeEach(() => {
    TestBed.configureTestingModule({
      imports: [ HttpClientTestingModule ]
    });
    service = TestBed.inject(NewClientSignalrService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
