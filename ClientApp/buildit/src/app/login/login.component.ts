import { Component, OnInit } from '@angular/core';
import { Router, ActivatedRoute } from '@angular/router';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { first } from 'rxjs/operators';

import { UserauthentificationService } from '../_services/userauthentification.service';
@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.scss'],
})
export class LoginComponent implements OnInit {
  public loginForm: FormGroup;
  public loading: boolean;
  public formSubbmited: boolean;
  public returnUrl: '';
  public error: '';

  constructor(
    private formBuilder: FormBuilder,
    private route: ActivatedRoute,
    private router: Router,
    private auth: UserauthentificationService
  ) {
    if (this.auth.currentUserInfo) {
      this.router.navigate(['']);
    }
  }
  get FormData() {
    return this.loginForm.controls;
  }
  ngOnInit(): void {
    this.loginForm = this.formBuilder.group({
      username: ['', [Validators.required, Validators.minLength(3)]],
      password: ['', Validators.required],
    });
  }

  Submit(e) {
    e.preventDefault();
    this.formSubbmited = true;
    if (this.loginForm.invalid) {
      return;
    }
    this.loading = true;

    this.auth
      .login(this.FormData.username.value, this.FormData.password.value)
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
