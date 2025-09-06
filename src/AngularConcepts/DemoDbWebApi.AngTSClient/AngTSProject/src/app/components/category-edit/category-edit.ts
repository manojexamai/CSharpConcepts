import { Component, OnInit } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ReactiveFormsModule, FormBuilder, Validators, FormGroup } from '@angular/forms';
import { ActivatedRoute, RouterModule, Router } from '@angular/router';
import { CategoryService } from '../../services/category.service';
import { Category } from "../../services/category.model";

@Component({
  selector: 'app-category-edit',
  standalone: true,
  imports: [
    CommonModule,
    ReactiveFormsModule,
    RouterModule],
  templateUrl: './category-edit.html',
  styleUrls: ['./category-edit.css']
})
export class CategoryEdit implements OnInit {

  form: FormGroup;

  private categoryId!: number;

  constructor(
    private fb: FormBuilder,
    private route: ActivatedRoute,
    private router: Router,
    private categoryService: CategoryService
  ) {
    // Initialize the form
    this.form = this.fb.group({
      categoryName: ['', [Validators.required, Validators.maxLength(50)]]
    });
  }


  ngOnInit(): void {
    // Get the ID from the route
    this.categoryId = Number(this.route.snapshot.paramMap.get('id'));

    // Load category data
    this.categoryService.getCategory(this.categoryId).subscribe({
      next: (category) => {
        if (category) {
          this.form.patchValue({
            categoryName: category.categoryName
          });
        }
      },
      error: (err) => console.error('Error loading category', err)
    });
  }


  onSubmit(): void {

    if (this.form.invalid) return;

    const updatedCategory: Category = {
      categoryId: this.categoryId,
      ...this.form.getRawValue(),       // copy all the form fields into your new object (using "spread" JS feature)
      products: null
    };

    this.categoryService.updateCategory(this.categoryId, updatedCategory).subscribe({
      next: () => this.router.navigate(['/categories']),
      error: (err) => console.error('Error updating category', err)
    });
  }


  cancel(): void {
    this.router.navigate(['/categories']);
  }

}
