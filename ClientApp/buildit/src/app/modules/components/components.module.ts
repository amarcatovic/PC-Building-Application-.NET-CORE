import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { MatInputModule } from '@angular/material/input';
import { MatButtonModule } from '@angular/material/button';
import { MatDividerModule } from '@angular/material/divider';
import { MatSnackBarModule } from '@angular/material/snack-bar';
import { MatExpansionModule } from '@angular/material/expansion';
import { MatIconModule } from '@angular/material/icon';
import { MatTableModule } from '@angular/material/table';
import * as Components from './index';

import { ReactiveFormsModule } from '@angular/forms';

import { CoreModule } from '../../core/core.module';

@NgModule({
  declarations: [
    Components.LoginComponent,
    Components.HomeComponent,
    Components.RegisterComponent,
    Components.ProfileComponent,
    Components.BrowseProductComponent,
  ],
  imports: [
    CommonModule,
    MatInputModule,
    MatButtonModule,
    MatDividerModule,
    MatSnackBarModule,
    ReactiveFormsModule,
    MatExpansionModule,
    MatIconModule,
    MatTableModule,
    CoreModule,
  ],
})
export class ComponentsModule {}
