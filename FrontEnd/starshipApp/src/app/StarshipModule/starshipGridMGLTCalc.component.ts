import { Component, OnInit } from '@angular/core';
import { StarshipService } from './starship.service';
import { StarshipStops } from './starshipStops';

@Component({
  selector: 'app-starships-calc-mglt',
  templateUrl: './starshipMGLTCalc.component.html',
  styleUrls: ['./starshipMGLTCalc.component.css']
})
export class StarshipMGLTCalcComponent implements OnInit {

  columnDefs = [
    {headerName: 'Star ship Name', field: 'Name'},
    {headerName: 'Number of Stops to Resupply', field: 'NumberStops'},
    {headerName: 'Message Exception', field: 'Alert', width: 600}
  ];

  rowData: StarshipStops[] = [];
  selectedMGLT: boolean;
  disabledButton: boolean;
  gridApi;
  overlayLoadingTemplate;

  constructor(private starshipService: StarshipService) {
    this.overlayLoadingTemplate =
    '<span class="ag-overlay-loading-center">Please wait while your rows are loading</span>';
   }

  ngOnInit() {
    this.selectedMGLT = false;
    this.disabledButton = false;
  }

  calculateStops(distanceMGLT: number): void {
    this.selectedMGLT = false;
    this.disabledButton = true;
    this.gridApi.showLoadingOverlay();
    this.starshipService.getNumberStopsToResupply(distanceMGLT)
    .then(result => result.json() as StarshipStops[])
    .then(data => this.rowData = data)
    .then(() => this.selectedMGLT = true)
    .then(() => this.disabledButton = false)
    .then(() => this.gridApi.showLoadingOverlay());
  }

  onGridReady(params) {
    this.gridApi = params.api;
  }

}
