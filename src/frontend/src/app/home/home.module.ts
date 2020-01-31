import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { HomeRoutingModule } from './home-routing.module';
import { HomeComponent } from './home.component';
import { BaseComponentsModule } from '../shared/modules/base-components.module';
import { EnvironmentsComponent } from './environments/environments.component';
import { EnvironmentService } from './environments/services/environment.service';


@NgModule({
  declarations: [
    HomeComponent,
    EnvironmentsComponent,
  ],
  providers: [
    EnvironmentService,
  ],
  imports: [
    CommonModule,
    HomeRoutingModule,

    BaseComponentsModule,
  ]
})
export class HomeModule { }
