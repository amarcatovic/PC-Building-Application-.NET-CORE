import { Injectable } from '@angular/core';
import {
  HttpRequest,
  HttpHandler,
  HttpEvent,
  HttpInterceptor,
} from '@angular/common/http';
import { Observable, throwError } from 'rxjs';
import { catchError } from 'rxjs/operators';

import { UserauthentificationService } from '../services';
@Injectable()
export class ErrorInterceptor implements HttpInterceptor {
  constructor(private auth: UserauthentificationService) {}

  intercept(
    request: HttpRequest<any>,
    next: HttpHandler
  ): Observable<HttpEvent<any>> {
    return next.handle(request).pipe(
      catchError((err) => {
        if (err.status == 401) {
          this.auth.logout();
        }
        const error = err.error.message || err.statusText;
        return throwError(error);
      })
    );
  }
}