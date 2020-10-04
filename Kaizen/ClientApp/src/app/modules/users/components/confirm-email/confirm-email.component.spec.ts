import { HttpClientTestingModule } from '@angular/common/http/testing';
import { async, ComponentFixture, TestBed } from '@angular/core/testing';
import { RouterTestingModule } from '@angular/router/testing';
import { SharedModule } from '@app/shared/shared.module';
import { ConfirmEmailComponent } from './confirm-email.component';

describe('ConfirmEmailComponent', () => {
  let component: ConfirmEmailComponent;
  let fixture: ComponentFixture<ConfirmEmailComponent>;

  beforeEach(
    async(() => {
      TestBed.configureTestingModule({
        imports: [ HttpClientTestingModule, RouterTestingModule, SharedModule ],
        declarations: [ ConfirmEmailComponent ]
      }).compileComponents();
    })
  );

  beforeEach(() => {
    fixture = TestBed.createComponent(ConfirmEmailComponent);
    component = fixture.componentInstance;
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
