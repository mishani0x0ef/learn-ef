import { BaseComponent } from './base.component';
import { Title } from '@angular/platform-browser';
import { OnInit } from '@angular/core';

export abstract class PageComponent extends BaseComponent implements OnInit {
    protected abstract get initialTitle(): string;

    constructor(private titleService: Title) {
        super();
    }

    ngOnInit(): void {
        this.titleService.setTitle(this.initialTitle);
    }

    setTitle(title: string): void {
        this.titleService.setTitle(title);
    }
}
