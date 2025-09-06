import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';

import { CategoryList } from './components/category-list/category-list';        // Imports the list component.
import { CategoryCreate } from './components/category-create/category-create';  // Imports the create component.
import { CategoryEdit } from './components/category-edit/category-edit';        // Imports the edit component.
import { CategoryDelete } from './components/category-delete/category-delete';  // Imports the delete component.

// Register the Routes
const routes: Routes = [
  { path: '', redirectTo: '/categories', pathMatch: 'full' },
  { path: 'categories', component: CategoryList },
  { path: 'categories/create', component: CategoryCreate },
  { path: 'categories/edit/:id', component: CategoryEdit },
  { path: 'categories/delete/:id', component: CategoryDelete }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
