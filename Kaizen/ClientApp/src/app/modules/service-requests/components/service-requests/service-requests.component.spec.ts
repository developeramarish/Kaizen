import { HttpClientTestingModule } from '@angular/common/http/testing';
import { async, ComponentFixture, TestBed } from '@angular/core/testing';
import { RouterTestingModule } from '@angular/router/testing';
import { SharedModule } from '@app/shared/shared.module';
import { ServiceRequestsComponent } from './service-requests.component';

describe('ServiceRequestsComponent', () => {
  let component: ServiceRequestsComponent;
  let fixture: ComponentFixture<ServiceRequestsComponent>;

  beforeEach(
    async(() => {
      TestBed.configureTestingModule({
        imports: [ HttpClientTestingModule, RouterTestingModule, SharedModule ],
        declarations: [ ServiceRequestsComponent ]
      }).compileComponents();
    })
  );

  beforeEach(() => {
    fixture = TestBed.createComponent(ServiceRequestsComponent);
    component = fixture.componentInstance;
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
