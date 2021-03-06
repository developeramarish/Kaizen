import { Directive } from '@angular/core';
import { AbstractControl, AsyncValidator, NG_ASYNC_VALIDATORS, ValidationErrors } from '@angular/forms';
import { CheckEmployeeExistsService } from '@core/services/check-employee-exists.service';
import { Observable } from 'rxjs';
import { map } from 'rxjs/operators';

@Directive({
  selector: '[appUniqueEmployee]',
  providers: [ { provide: NG_ASYNC_VALIDATORS, useExisting: UniqueEmployeeDirective, multi: true } ]
})
export class UniqueEmployeeDirective implements AsyncValidator {
  constructor(private checkEmployeeExists: CheckEmployeeExistsService) {}

  validate(control: AbstractControl): Promise<ValidationErrors> | Observable<ValidationErrors> {
    const id = control.value;
    return this.checkEmployeeExists.checkEntityExists(id).pipe(
      map((result) => {
        if (result) {
          return { employeeExists: true };
        }
        return null;
      })
    );
  }
}
