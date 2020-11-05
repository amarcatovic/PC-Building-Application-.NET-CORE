import { Injectable, Output } from '@angular/core';
import { HttpClient } from '@angular/common/http';

import { BehaviorSubject, Observable } from 'rxjs';
import { map } from 'rxjs/operators';
import { of } from 'rxjs';
import { environment } from '../../../environments/environment';
import { User } from '../../shared/models';

interface userApi {
  token: string;
  tokenExpirationDate: string;
  user: User;
}
@Injectable({
  providedIn: 'root',
})
export class UserauthentificationService {
  public currentUserDefault: BehaviorSubject<userApi>;
  public currentUser: Observable<userApi>;

  constructor(private http: HttpClient) {
    this.currentUserDefault = new BehaviorSubject<userApi>(
      JSON.parse(localStorage.getItem('user'))
    );
    this.currentUser = this.currentUserDefault.asObservable();
  }

  public get currentUserInfo(): userApi {
    return this.currentUserDefault.value;
  }
  login(username: string, password: string) {
    return this.http
      .post(`${environment.apiUrl}api/users/login`, { username, password })
      .pipe(
        map((user: userApi) => {
          localStorage.setItem('user', JSON.stringify(user));
          this.currentUserDefault.next(user);
          return user;
        })
      );
  }
  registration(username: String, email: string, password: string) {
    return this.http.post(`${environment.apiUrl}api/users/register`, {
      username,
      email,
      password,
    });
  }
  logout() {
    localStorage.removeItem('user');
    this.currentUserDefault.next(null);
  }
  checkUserExist(username: string) {
    return username
      ? this.http.get(`${environment.apiUrl}api/Users/exists/${username}`)
      : of('No');
  }
  userInfo(id: string) {
    return this.http.get(`${environment.apiUrl}api/users/${id}`);
  }
}
