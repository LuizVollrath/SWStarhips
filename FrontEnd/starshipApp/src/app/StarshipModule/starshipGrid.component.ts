import { Component, OnInit } from '@angular/core';
import { StarshipService } from './starship.service';
import { Starship } from './starship';

@Component({
  selector: 'app-starships-grid',
  templateUrl: './starshipGrid.component.html',
  styleUrls: ['./starshipGrid.component.css']
})
export class StarshipGridComponent implements OnInit {

  gridApi;
  columnDefs = [
    {headerName: 'Star ship Name', field: 'Name'},
    {headerName: 'Consumables', field: 'Consumables'},
    {headerName: 'MGLT', field: 'MGLT'}
  ];

  rowData: Starship[] = [];
  dataLoaded: boolean;
  overlayLoadingTemplate;

  constructor(private starshipService: StarshipService) {
    this.overlayLoadingTemplate =
      '<span class="ag-overlay-loading-center">Please wait while your rows are loading</span>';
   }

  ngOnInit() {
    this.dataLoaded = false;
  }

  onGridReady(params) {
    this.gridApi = params.api;
    this.gridApi.showLoadingOverlay();
    this.starshipService.getStarships().then(result => result.json() as Starship[])
      .then(data => this.rowData = data)
      .then(() => this.dataLoaded = true)
      .then(() => this.gridApi.hideOverlay());
  }

}
