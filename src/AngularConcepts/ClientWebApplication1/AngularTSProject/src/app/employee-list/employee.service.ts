import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { Employee } from './employee.model';

@Injectable({
  providedIn: 'root' // available everywhere in the app
})
export class EmployeeService {

  private apiUrl = 'https://localhost:7160/Employees';        // API endpoint

  constructor(private http: HttpClient) {
  }

  getEmployees(): Observable<Employee[]> {
    return this.http.get<Employee[]>(this.apiUrl);
  }
}
