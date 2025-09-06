// src/app/services/category.service.ts
import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { Category } from "./category.model";

@Injectable({
  providedIn: 'root'
})
export class CategoryService {

  private apiUrl = 'https://localhost:7178/api/categories';     // The Web API endpoint

  constructor(private http: HttpClient) { }

  // GET all categories
  getCategories(): Observable<Category[]> {
    return this.http.get<Category[]>(this.apiUrl);
  }

  // GET single category by id
  getCategory(id: number): Observable<Category> {
    return this.http.get<Category>(`${this.apiUrl}/${id}`);
  }

  // CREATE new category
  createCategory(category: Partial<Category>): Observable<Category> {
    return this.http.post<Category>(this.apiUrl, category);
  }

  // UPDATE category by id
  updateCategory(id: number, category: Category): Observable<Category> {
    return this.http.put<Category>(`${this.apiUrl}/${id}`, category);
  }

  // DELETE category by id
  deleteCategory(id: number): Observable<void> {
    return this.http.delete<void>(`${this.apiUrl}/${id}`);
  }

}

