import { Component } from '@angular/core';
import { FleetService, WhereIsMyFleetServicesFeaturesFleetListDronesResponseDrone } from 'src/api';

@Component({
  selector: 'app-home',
  templateUrl: './drones.component.html',
  styles: [ "agm-map { \
    height: 80vh;     \
  }"]
})
export class DronesComponent {
  public markers: WhereIsMyFleetServicesFeaturesFleetListDronesResponseDrone[];
  /**
   *
   */
  constructor(private fleetService: FleetService) { }
  async ngOnInit() {
    var fleet = await this.fleetService.fleetListGet().toPromise();
    this.markers = fleet.list;
  }
}
