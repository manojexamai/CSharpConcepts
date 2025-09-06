import { NgModule, provideBrowserGlobalErrorListeners } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { provideHttpClient } from '@angular/common/http';   // Import the HttpClientModule class

import { AppRoutingModule } from './app-routing-module';
import { App } from './app';
import { CategoryList } from './components/category-list/category-list';      // Imports the list component.

@NgModule({
  declarations: [
    App
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    CategoryList                              // registers the list component for DI
  ],
  providers: [
    provideBrowserGlobalErrorListeners(),
    provideHttpClient()                       // ensure that HttpClient is added to the Providers Collection through DI
  ],
  bootstrap: [App]
})
export class AppModule { }
