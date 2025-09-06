import { Component, signal } from '@angular/core';

@Component({
  selector: 'app-root',
//  templateUrl: './app.html',
  standalone: false,
  styleUrl: './app.css',

  template:
    `
      <router-outlet><router-outlet>

      <h1>{{ title }}</h1>
    `
})
export class App {
  protected readonly title = 'Angular TS Client for DemoDbWebApi';
}
