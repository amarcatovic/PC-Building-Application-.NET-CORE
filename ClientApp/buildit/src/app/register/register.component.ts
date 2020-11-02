import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Router, ActivatedRoute } from '@angular/router';
import { first } from 'rxjs/operators';

import { UserauthentificationService } from '../_services/userauthentification.service';
import { PasswordValidator, RegValidator, UniquUser } from '../_validators';
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

  constructor(
    private auth: UserauthentificationService,
    private formBuilder: FormBuilder,
    private route: ActivatedRoute,
    private router: Router
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
          [
            Validators.required,
            Validators.minLength(3),
            RegValidator(/[a,A]dmin/),
            UniquUser(this.auth),
          ],
        ],
        password: ['', [Validators.required, Validators.minLength(8)]],
        email: ['', [Validators.required, Validators.email]],
        confirmPassword: ['', [Validators.required, Validators.minLength(8)]],
      },
      { validator: PasswordValidator }
    );
  }
  Submit(e) {
    e.preventDefault();
    this.formSubmitted = true;
    if (this.registrationForm.invalid) {
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
          this.router.navigate(['login']);
        },
        (error) => {
          this.error = error;
          this.loading = false;
        }
      );
  }
}
