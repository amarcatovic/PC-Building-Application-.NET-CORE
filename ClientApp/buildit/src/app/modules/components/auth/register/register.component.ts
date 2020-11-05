import { Component, OnInit } from '@angular/core';
import {
  FormBuilder,
  FormGroup,
  Validators,
  FormControl,
  FormGroupDirective,
  NgForm,
} from '@angular/forms';
import { Router, ActivatedRoute } from '@angular/router';
import { ErrorStateMatcher } from '@angular/material/core';
import { first } from 'rxjs/operators';

import { UserauthentificationService } from '../../../services';
import {
  PasswordValidator,
  RegValidator,
  UniquUser,
} from '../../../validators';
import { MatSnackBar } from '@angular/material/snack-bar';

export class MyErrorStateMatcher implements ErrorStateMatcher {
  isErrorState(
    control: FormControl | null,
    form: FormGroupDirective | NgForm | null
  ): boolean {
    const invalidCtrl = !!(control && control.invalid && control.parent.dirty);
    const invalidParent = !!(
      control &&
      control.parent &&
      control.parent.invalid &&
      control.parent.dirty
    );

    return invalidCtrl || invalidParent;
  }
}

@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.scss'],
})
export class RegisterComponent implements OnInit {
  public error: '';
  public registrationForm: FormGroup;
  public loading: boolean;
  public formSubmitted: boolean;
  public redirectUrl: '';
  public matcher = new MyErrorStateMatcher();
  constructor(
    private auth: UserauthentificationService,
    private formBuilder: FormBuilder,
    private route: ActivatedRoute,
    private router: Router,
    private _snackBar: MatSnackBar
  ) {
    if (this.auth.currentUserInfo) {
      this.router.navigate(['']);
    }
  }
  get formData() {
    return this.registrationForm.controls;
  }
  ngOnInit(): void {
    this.registrationForm = this.formBuilder.group(
      {
        username: [
          '',
          {
            validators: [
              Validators.required,
              Validators.minLength(3),
              RegValidator(/[a,A]dmin/),
            ],
            asyncValidators: [UniquUser(this.auth)],
            updateOn: 'blur',
          },
        ],
        password: [''],
        confirmPassword: [''],
        email: ['', [Validators.required, Validators.email]],
      },
      { validator: PasswordValidator }
    );
  }
  Submit(e) {
    e.preventDefault();
    this.formSubmitted = true;
    if (this.registrationForm.invalid) {
      this._snackBar.open('Please fix errors', 'Close', {
        duration: 2000,
      });
      return;
    }
    this.loading = true;

    this.auth
      .registration(
        this.formData.username.value,
        this.formData.email.value,
        this.formData.password.value
      )
      .pipe(first())
      .subscribe(
        (data) => {
          this.router.navigate(['']);
        },
        (error) => {
          this.error = error;
          this.loading = false;
        }
      );
  }
}
