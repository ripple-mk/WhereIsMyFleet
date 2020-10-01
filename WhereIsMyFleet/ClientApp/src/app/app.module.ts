import { BrowserModule } from '@angular/platform-browser';
import { NgModule, isDevMode } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';
import { RouterModule } from '@angular/router';
import { CommonModule } from '@angular/common';

import { AppComponent } from './app.component';
import { NavMenuComponent } from './nav-menu/nav-menu.component';
import { DronesComponent } from './fleet/drones.component';
import { ApiModule } from '../api/api.module';
import { BASE_PATH } from '../api/variables';
import { Configuration, ConfigurationParameters } from '../api';
import { AddComponentComponent } from './add-component/add-component.component';
import { AgmCoreModule } from '@agm/core';

@NgModule({
  declarations: [
    AppComponent,
    NavMenuComponent,
    DronesComponent,
    AddComponentComponent
  ],
  imports: [
    CommonModule,
    BrowserModule.withServerTransition({ appId: 'ng-cli-universal' }),
    HttpClientModule,
    FormsModule,
    RouterModule.forRoot([
      { path: '', component: DronesComponent, pathMatch: 'full' },
      { path: 'add', component: AddComponentComponent, pathMatch: 'full' },
    ]),
    ApiModule,
    ApiModule.forRoot(apiConfigFactory),
    AgmCoreModule.forRoot({
      apiKey: ''
    })
  ],
  providers: [
    {
      provide: BASE_PATH, useFactory: () => {
        return "http://localhost:5000";
      }
    }
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }


export function apiConfigFactory(): Configuration {
  const configParams: ConfigurationParameters = {

  };
  configParams.apiKeys = { [""]: "" };
  return new Configuration(configParams);
}

