// To generate the Component:
// Right-Click on "app" folder and choose "Open in Terminal"
// > ng generate component employee-list

import { Component, OnInit } from '@angular/core';
import { EmployeeService } from './employee.service';
import { Employee } from './employee.model';


@Component({
  selector: 'app-employee-list',
  standalone: false,
  templateUrl: './employee-list.html',
  styleUrl: './employee-list.css'
})
export class EmployeeList implements OnInit {

  employees: Employee[] = [];
  errorMessage = '';

  constructor(private employeeService: EmployeeService) { }


  ngOnInit(): void {
    this.loadEmployees();
  }


  loadEmployees(): void {
    this.employeeService.getEmployees().subscribe({
      next: (data) => this.employees = data,
      error: (err) => this.errorMessage = 'Error: ' + err.message
    });
  }

}
