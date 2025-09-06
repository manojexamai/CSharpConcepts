import { Component, signal } from '@angular/core';

@Component({
  selector: 'app-root',
//  templateUrl: './app.html',
  standalone: false,
  styleUrl: './app.css',

  template:
    `
      <h1>{{ title }}</h1>

      <app-category-list></app-category-list>
    `
})
export class App {
  protected readonly title = 'Angular TS Client for DemoDbWebApi';
}
