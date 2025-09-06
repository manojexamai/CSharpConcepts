import { Component } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ReactiveFormsModule, FormBuilder, Validators, FormGroup } from '@angular/forms';
import { RouterModule, Router } from '@angular/router';
import { CategoryService } from '../../services/category.service';

@Component({
  selector: 'app-category-create',
  standalone: true,
  imports: [
    CommonModule,
    ReactiveFormsModule,
    RouterModule],
  templateUrl: './category-create.html',
  styleUrls: [ './category-create.css' ]
})
export class CategoryCreate {

  form: FormGroup;        // explicitly type the form.


  constructor(
    private fb: FormBuilder,
    private categoryService: CategoryService,
    private router: Router
  ) {

    // initialize the form here
    this.form = this.fb.group({
      categoryName: ['', [Validators.required, Validators.maxLength(50)]]
    });

  }


  onSubmit(): void {
    if (this.form.invalid) return;

    this.categoryService.createCategory(this.form.value).subscribe({
      next: () => this.router.navigate(['/categories'])
    });
  }

}
