import { Component, OnInit } from '@angular/core';
import { User } from 'src/app/shared/models';
import { UserauthentificationService } from '../../services';
import { map } from 'rxjs/operators';
@Component({
  selector: 'app-profile',
  templateUrl: './profile.component.html',
  styleUrls: ['./profile.component.scss'],
})
export class ProfileComponent implements OnInit {
  currentUser: User;
  step: number = 0;
  constructor(private auth: UserauthentificationService) {
    this.currentUser = new User();
  }

  ngOnInit(): void {
    this.auth.currentUser
      .pipe(
        map((data) => {
          return data.user;
        })
      )
      .subscribe((data) => {
        this.auth
          .userInfo(data.id)
          .pipe(
            map((data) => {
              return data;
            })
          )
          .subscribe((data) => {
            this.currentUser = data;
            console.log(this.currentUser);
          });
      });
  }
  setStep(step: number) {
    this.step = step;
  }
  prevStep() {
    this.step--;
  }
  nextStep() {
    this.step++;
  }
}
