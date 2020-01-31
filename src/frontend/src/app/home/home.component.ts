import { Component } from '@angular/core';
import { PageComponent } from '../shared/base';
import { Title } from '@angular/platform-browser';

@Component({
    selector: 'app-home',
    templateUrl: './home.component.html',
    styleUrls: ['./home.component.scss']
})
export class HomeComponent extends PageComponent {
    protected get initialTitle(): string {
        return 'Hub - Home';
    }

    constructor(titleService: Title) {
        super(titleService);
    }
}
