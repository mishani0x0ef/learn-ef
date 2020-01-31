import { Component, Input } from '@angular/core';
import { BaseComponent } from 'src/app/shared/base';
import { isEmpty } from 'lodash';

@Component({
    selector: 'app-section',
    template: `
    <div class="section__container">
        <h2>{{title}}</h2>
        <div class="section__separator"></div>
        <h4 *ngIf="hasDescription">{{description}}</h4>
    <div>
    `
})
export class SectionComponent extends BaseComponent {
    @Input()
    title: string;

    @Input()
    description: string;

    get hasDescription(): boolean {
        return !isEmpty(this.description);
    }

    constructor() {
        super();
    }
}
