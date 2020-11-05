import {
  AbstractControl,
  ValidatorFn,
  AsyncValidatorFn,
  ValidationErrors,
} from '@angular/forms';
import { HttpClient } from '@angular/common/http';
import {
  map,
  take,
  distinctUntilChanged,
  debounceTime,
  switchMapTo,
  tap,
} from 'rxjs/operators';
import { UserauthentificationService } from '../services';

import { of, Observable } from 'rxjs';
export function UniquUser(
  service: UserauthentificationService
): AsyncValidatorFn {
  return (control: AbstractControl): Observable<ValidationErrors | null> => {
    return service.checkUserExist(control.value).pipe(
      map((res) => {
        // if res is true, username exists, return true
        console.log(res);
        return res === 'Yes' ? { usernameExists: true } : null;
        // NB: Return null if there is no error
      })
    );
  };
}
// export function UniquUser(service: UserauthentificationService): ValidatorFn {
//   return (control: AbstractControl): { [key: string]: any } | null => {
//     if (!control.valueChanges || control.pristine) {
//       console.log('pocetno');
//       return of(null);
//     } else {
//       return control.valueChanges
//         .pipe(
//           map((event) => {
//             return event;
//           }),
//           debounceTime(500),
//           distinctUntilChanged(),
//           take(1),

//           tap(() => control.markAsTouched())
//         )
//         .subscribe((data) => {
//           service.checkUserExist(data).subscribe((data) => {
//             return data === 'Yes' ? { uniqueUser: { value: data } } : null;
//           });
//         });
//     }
//   };
// }
