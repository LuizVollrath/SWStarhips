import { NgModule } from '@angular/core';
import { RouterModule } from '@angular/router';
import { StarshipGridComponent } from './starshipGrid.component';
import { StarshipMGLTCalcComponent } from './starshipGridMGLTCalc.component';

@NgModule({
  imports: [
    RouterModule.forChild([
      { path: 'starships', component: StarshipGridComponent },
      { path: 'starships/calc', component: StarshipMGLTCalcComponent }
    ])
  ],
  exports: [RouterModule]
})
export class StarshipRoutingModule { }
