import { Component } from '@angular/core';
import { BaseComponent } from 'src/app/shared/base';

@Component({
    selector: 'app-environments',
    templateUrl: './environments.component.html',
})
export class EnvironmentsComponent extends BaseComponent {

    constructor() {
        super();
    }
}
