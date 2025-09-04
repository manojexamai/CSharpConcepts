// This is the App.Component file.

import { Component, OnInit, signal } from '@angular/core';
import { HelloService } from './hello.service';                 // register the HelloService

@Component({
  selector: 'app-root',
  // templateUrl: './app.html',
  standalone: false,
  styleUrl: './app.css',

  template:
    `
      <h1>{{ title }}</h1>
      <h3>{{ message }}</h3>
      <button (click)="loadMessage()">
        Get message from API
      </button>

      <hr />

      <h3>List of Employees</h3>
      <app-employee-list></app-employee-list>
    `

})

export class App implements OnInit {

  protected readonly title = 'My Angular SPA for WebApplication1';
  message = 'Loading';

  constructor(private helloService: HelloService) { }

  ngOnInit() {
    this.loadMessage();
  }

  loadMessage() {
    this.helloService.getHello().subscribe({
      next: (data) => this.message = data,
      error: (err) => this.message = 'Error: ' + err.message
    });
  }

}
