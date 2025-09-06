import { Component, OnInit } from '@angular/core';
import { CommonModule } from '@angular/common';   // import the common module 
import { RouterModule } from '@angular/router';   // import the router module
import { CategoryService } from '../../services/category.service';
import { Category } from '../../services/category.model';

@Component({
  selector: 'app-category-list',
  standalone: true,
  imports: [
    CommonModule,                // to enable *ngIf, *ngFor in the html template.
    RouterModule                 // to enable routing
  ],
  templateUrl: './category-list.html',
  styleUrls: ['./category-list.css']
})
export class CategoryList implements OnInit {

  categories: Category[] = [];
  loading = true;

  constructor(private categoryService: CategoryService) { }

  ngOnInit(): void {
    this.loadCategories();
  }

  loadCategories(): void {
    this.categoryService.getCategories().subscribe({
      next: (data) => {
        this.categories = data;
        this.loading = false;
      },
      error: (err) => {
        console.error('Error fetching categories', err);
        this.loading = false;
      }
    });
  }

}
