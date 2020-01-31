import { Component, Input } from '@angular/core';
import { BaseComponent } from 'src/app/shared/base';
import { Environment } from '../environments/models';

@Component({
    selector: 'app-environment-card',
    template: `
    <mat-card>
        <mat-card-header>
          <mat-card-title>{{environment.name}}</mat-card-title>
          <mat-card-subtitle>{{environment.description}}</mat-card-subtitle>
        </mat-card-header>
        <mat-card-actions class="has-text-centered">
          <button mat-button>View Details</button>
        </mat-card-actions>
    </mat-card>
    `,
})
export class EnvironmentCardComponent extends BaseComponent {
    @Input()
    environment: Environment;
}
