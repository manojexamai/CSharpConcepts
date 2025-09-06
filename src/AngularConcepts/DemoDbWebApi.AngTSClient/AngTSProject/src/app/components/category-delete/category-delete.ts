import { Component, OnInit } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ActivatedRoute, RouterModule, Router } from '@angular/router';
import { CategoryService } from '../../services/category.service';
import { Category } from '../../services/category.model'

@Component({
  selector: 'app-category-delete',
  standalone: true,
  imports: [CommonModule, RouterModule],
  templateUrl: './category-delete.html',
  styleUrls: ['./category-delete.css']
})
export class CategoryDelete implements OnInit {

  category?: Category;
  private categoryId!: number;


  constructor(
    private route: ActivatedRoute,
    private router: Router,
    private categoryService: CategoryService
  ) { }


  ngOnInit(): void {
    this.categoryId = Number(this.route.snapshot.paramMap.get('id'));
    this.categoryService.getCategory(this.categoryId).subscribe({
      next: (cat) => this.category = cat,
      error: (err) => console.error('Error loading category', err)
    });
  }


  confirmDelete(): void {
    if (!this.category) return;

    this.categoryService.deleteCategory(this.categoryId).subscribe({
      next: () => this.router.navigate(['/categories']),
      error: (err) => console.error('Error deleting category', err)
    });
  }


  cancel(): void {
    this.router.navigate(['/categories']);
  }

}

