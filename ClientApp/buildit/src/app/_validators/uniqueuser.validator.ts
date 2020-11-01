import { AbstractControl, ValidatorFn } from '@angular/forms';
import { HttpClient } from '@angular/common/http';
import {
  map,
  take,
  distinctUntilChanged,
  debounceTime,
  switchMapTo,
  tap,
} from 'rxjs/operators';
import { UserauthentificationService } from '../_services/userauthentification.service';

import { of } from 'rxjs';
export function UniquUser(service: UserauthentificationService): ValidatorFn {
  return (control: AbstractControl): { [key: string]: any } | null => {
    if (!control.valueChanges || control.pristine || control.dirty) {
      return of(null);
    } else {
      return control.valueChanges
        .pipe(
          debounceTime(300),
          distinctUntilChanged(),
          take(1),
          switchMapTo(service.checkUserExist(control.value)),
          tap(() => control.markAsTouched())
        )
        .subscribe((data) => {
          console.log('odgovor' + data);
          return data == 'Yes' ? { userExist: true } : null;
        });
    }
  };
}
