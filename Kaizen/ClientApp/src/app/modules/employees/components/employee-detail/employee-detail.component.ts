import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { Employee } from '@modules/employees/models/employee';
import { EmployeeService } from '@modules/employees/services/employee.service';
import { ObservableStatus } from '@shared/models/observable-with-status';
import { Observable } from 'rxjs';

@Component({
  selector: 'app-employee-detail',
  templateUrl: './employee-detail.component.html',
  styleUrls: [ './employee-detail.component.scss' ]
})
export class EmployeeDetailComponent implements OnInit {
  public ObsStatus: typeof ObservableStatus = ObservableStatus;

  employee$: Observable<Employee>;

  constructor(private employeeService: EmployeeService, private activatedRoute: ActivatedRoute) {}

  ngOnInit(): void {
    this.loadData();
  }

  private loadData(): void {
    const id = this.activatedRoute.snapshot.paramMap.get('id');
    this.employee$ = this.employeeService.getEmployee(id);
  }
}
