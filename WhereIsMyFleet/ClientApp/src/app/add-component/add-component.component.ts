import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { FleetService, WhereIsMyFleetServicesFeaturesToDosAddDroneRequest } from 'src/api';

@Component({
  selector: 'app-add-component',
  templateUrl: './add-component.component.html'
})
export class AddComponentComponent implements OnInit {

  constructor(private fleetService: FleetService, private router: Router) { }

  ngOnInit() {

  }
  public model: WhereIsMyFleetServicesFeaturesToDosAddDroneRequest;
  public name: string;
  public latitude: number;
  public longitude: number;

  addDrone() {
    this.model = {
      latitude: this.latitude,
      longitude: this.longitude,
      name: this.name
    }
    this.fleetService.fleetAddDronePost(this.model).subscribe(() => {
      this.router.navigate([`/`]);
    });
  }
}
