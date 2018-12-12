import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { AgGridModule } from 'ag-grid-angular';
import { MatInputModule } from '@angular/material/input';
import { MatButtonModule } from '@angular/material/button';

import { StarshipRoutingModule } from './starship.routing';
import { StarshipGridComponent } from './starshipGrid.component';
import { StarshipMGLTCalcComponent } from './starshipGridMGLTCalc.component';
import { StarshipService } from './starship.service';

@NgModule({
  declarations: [
    StarshipGridComponent,
    StarshipMGLTCalcComponent
  ],
  imports: [
    BrowserModule,
    StarshipRoutingModule,
    MatButtonModule,
    MatInputModule,
    AgGridModule.withComponents(null)
  ],
  providers: [StarshipService],
  bootstrap: [StarshipGridComponent],
  exports : [StarshipGridComponent, StarshipMGLTCalcComponent]
})
export class StarshipModule { }
