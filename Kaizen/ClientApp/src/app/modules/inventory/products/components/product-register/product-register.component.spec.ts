import { HttpClientTestingModule } from '@angular/common/http/testing';
import { ComponentFixture, TestBed, waitForAsync } from '@angular/core/testing';
import { RouterTestingModule } from '@angular/router/testing';
import { SharedModule } from '@app/shared/shared.module';
import { ProductRegisterComponent } from './product-register.component';

describe('ProductRegisterComponent', () => {
  let component: ProductRegisterComponent;
  let fixture: ComponentFixture<ProductRegisterComponent>;

  beforeEach(
    waitForAsync(() => {
      TestBed.configureTestingModule({
        imports: [ HttpClientTestingModule, RouterTestingModule, SharedModule ],
        declarations: [ ProductRegisterComponent ]
      }).compileComponents();
    })
  );

  beforeEach(() => {
    fixture = TestBed.createComponent(ProductRegisterComponent);
    component = fixture.componentInstance;
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
