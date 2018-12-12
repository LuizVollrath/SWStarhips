import { Injectable } from '@angular/core';
import { environment } from '../../environments/environment';

@Injectable()
export class StarshipService {

  constructor() {
  }

  getStarships(): Promise<any> {
    return fetch(environment.serverHost + 'starships');
  }

  getNumberStopsToResupply(distanceInMGLT: number): Promise<any> {
    return fetch(environment.serverHost + 'starships/stopsUntil/' + distanceInMGLT);
  }
}
