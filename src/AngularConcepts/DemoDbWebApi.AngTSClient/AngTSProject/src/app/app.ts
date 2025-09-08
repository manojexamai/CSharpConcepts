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

      <!--
         To embed the component, place this outside the HTML comment block:
          <app-category-list></app-category-list>
      -->
    `
})
export class App {
  protected readonly title = 'Angular TS Client for DemoDbWebApi';
}
