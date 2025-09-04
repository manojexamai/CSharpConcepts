import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})

export class HelloService {

  private apiUrl = 'https://localhost:7160/';

  // Constructor receives the HttpClientModule from the DI provider container.
  constructor(private http: HttpClient) {
  }


  getHello(): Observable<string> {

    console.log("getHello() called!!!");

    return this.http.get(this.apiUrl, { responseType: 'text' });
  }

}
