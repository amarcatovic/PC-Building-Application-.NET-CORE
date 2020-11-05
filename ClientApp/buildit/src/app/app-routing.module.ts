import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';

//components
import * as Components from './modules/components';
//guards
import { AuthGuard } from './modules/guards';
const routes: Routes = [
  { path: '', component: Components.HomeComponent },
  {
    path: 'user',
    component: Components.ProfileComponent,
    canActivate: [AuthGuard],
  },
  { path: 'login', component: Components.LoginComponent },
  { path: 'products', component: Components.BrowseProductComponent },
  { path: 'register', component: Components.RegisterComponent },
  { path: '**', component: Components.HomeComponent },
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule],
})
export class AppRoutingModule {}
