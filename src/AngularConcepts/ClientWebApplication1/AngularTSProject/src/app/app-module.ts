import { NgModule, provideBrowserGlobalErrorListeners } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

// Import the HttpClientModule class
import { provideHttpClient } from '@angular/common/http';         

import { AppRoutingModule } from './app-routing-module';
import { App } from './app';

@NgModule({
  declarations: [
    App
  ],
  imports: [
    BrowserModule,
    AppRoutingModule
  ],
  providers: [
    provideBrowserGlobalErrorListeners(),
    provideHttpClient()                          // ensures that HttpClient is provided in the Services through DI
  ],
  bootstrap: [App]
})
export class AppModule { }
