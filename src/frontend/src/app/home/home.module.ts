import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { HomeRoutingModule } from './home-routing.module';
import { HomeComponent } from './home.component';
import { BaseComponentsModule } from '../shared/modules/base-components.module';
import { EnvironmentsComponent } from './environments/environments.component';
import { EnvironmentService } from './environments/services/environment.service';
import { MatCardModule, MatButtonModule } from '@angular/material';
import { EnvironmentCardComponent } from './environment-card/environment-card.component';


@NgModule({
  declarations: [
    HomeComponent,
    EnvironmentsComponent,
    EnvironmentCardComponent,
  ],
  providers: [
    EnvironmentService,
  ],
  imports: [
    CommonModule,
    HomeRoutingModule,

    MatButtonModule,
    MatCardModule,

    BaseComponentsModule,
  ]
})
export class HomeModule { }
