import { AbstractControl, ValidatorFn } from '@angular/forms';

export function RegValidator(forrbidenName: RegExp): ValidatorFn {
  return (control: AbstractControl): { [key: string]: any } | null => {
    const forbidden = forrbidenName.test(control.value);
    return forbidden ? { forbiddenName: { value: control.value } } : null;
  };
}
