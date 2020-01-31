import { Component, OnInit } from '@angular/core';
import { BaseComponent } from 'src/app/shared/base';
import { EnvironmentService } from './services/environment.service';
import { Observable } from 'rxjs';
import { Environment } from './models';

@Component({
    selector: 'app-environments',
    templateUrl: './environments.component.html',
})
export class EnvironmentsComponent extends BaseComponent implements OnInit {
    $environments: Observable<Environment[]>;

    constructor(private envService: EnvironmentService) {
        super();
    }

    ngOnInit(): void {
        this.$environments = this.envService.getEnvironments();
    }
}
