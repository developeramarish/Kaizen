import { NgModule } from '@angular/core';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { SharedModule } from '@shared/shared.module';
import { ServiceRequestDetailComponent } from './components/service-request-detail/service-request-detail.component';
import { ServiceRequestNewDateComponent } from './components/service-request-new-date/service-request-new-date.component';
import { ServiceRequestProcessComponent } from './components/service-request-process/service-request-process.component';
import { ServiceRequestRegisterComponent } from './components/service-request-register/service-request-register.component';
import { ServiceRequestsComponent } from './components/service-requests/service-requests.component';
import { ServiceRequestsRoutingModule } from './service-requests-routing.module';

@NgModule({
  declarations: [
    ServiceRequestRegisterComponent,
    ServiceRequestDetailComponent,
    ServiceRequestsComponent,
    ServiceRequestNewDateComponent,
    ServiceRequestProcessComponent
  ],
  imports: [ SharedModule, ServiceRequestsRoutingModule, FormsModule, ReactiveFormsModule ],
  exports: [ ServiceRequestDetailComponent ]
})
export class ServiceRequestsModule {}
