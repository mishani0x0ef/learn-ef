import { Component } from '@angular/core';
import { MatSlideToggleChange } from '@angular/material';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss']
})
export class AppComponent {
  title = 'Hub';

  changeTheme({ checked }: MatSlideToggleChange): void {
    // TODO: provide theme change between dark and light. MR
    alert('Oops! Not implemented yet.');
  }
}
