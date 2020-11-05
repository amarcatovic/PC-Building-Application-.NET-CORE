import { Component, OnInit } from '@angular/core';

import { UserauthentificationService } from '../../../modules/services/userauthentification.service';
import { map } from 'rxjs/operators';
@Component({
  selector: 'app-nav',
  templateUrl: './nav.component.html',
  styleUrls: ['./nav.component.scss'],
})
export class NavComponent implements OnInit {
  user: any;
  constructor(private auth: UserauthentificationService) {}

  ngOnInit(): void {
    this.auth.currentUser
      .pipe(
        map((data) => {
          return data;
        })
      )
      .subscribe((data) => {
        this.user = data;
      });
  }
  Logout() {
    this.auth.logout();
    document.location.href = document.location.href;
  }
  User() {
    return this.user.user;
  }
}
