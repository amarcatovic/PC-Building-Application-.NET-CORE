import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { MatToolbarModule } from '@angular/material/toolbar';
import * as layout from './layout';

@NgModule({
  declarations: [layout.NavComponent, layout.CoverComponent],
  imports: [CommonModule, MatToolbarModule],
  exports: [layout.NavComponent, layout.CoverComponent],
  providers: [],
})
export class CoreModule {}
