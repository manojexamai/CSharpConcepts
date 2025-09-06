# 📝 Angular Client for ASP.NET Web API (CRUD on Categories)

This guide documents the steps to build an Angular (v21) client for an ASP.NET Web API that manages **Categories**.

---

## 🚀 1. Project Setup

1. Create a new Angular TypeScript Client project in **Visual Studio 2022**.  
   The template generates:
   - `app.ts` (root component)
   - `app-module.ts` (NgModule entry)
   - `app.routes.ts` (routing)

2. Open **View > Terminal**. Use either **PowerShell** or **Developer Command Prompt** and navigate to the project folder:

   ```bash
   cd path\to\project
   ```

---

## 🔧 2. Service Layer

1. Generate the service:

   ```bash
   ng generate service services/category
   ```

   This creates:
   ```
   src/app/services/category.spec.ts
   src/app/services/category.ts
   ```

2. Rename `category.ts` → `category.service.ts`.  
3. Move the `Category` interface into its own file `category.model.ts`.

4. Register `HttpClient` in `app-module.ts`:

   ```ts
   import { provideHttpClient } from '@angular/common/http';

   @NgModule({
     providers: [
       provideHttpClient()
     ]
   })
   export class AppModule {}
   ```

---

## 📋 3. List Component

1. Generate a **standalone** list component:

   ```bash
   ng generate component components/category-list --standalone=true
   ```

   Files created:
   ```
   src/app/components/category-list/category-list.ts
   src/app/components/category-list/category-list.html
   src/app/components/category-list/category-list.css
   src/app/components/category-list/category-list.spec.ts
   ```

2. Ensure the component is registered in the **imports** section of `app-module.ts`, not in `declarations`.

3. Fetch categories in `category-list.ts` using `CategoryService`.

4. Update `category-list.html` to render a table.

5. Style with `category-list.css`.

6. In `app.ts`, load the list component.

---

## ➕ 4. CRUD Components

1. Generate components:

   ```bash
   ng generate component components/category-create --standalone=true
   ng generate component components/category-edit --standalone=true
   ng generate component components/category-delete --standalone=true
   ```

   Each generates `.ts`, `.html`, `.css`, and `.spec.ts`.

2. Implement service methods in `category.service.ts`:

   ```ts
   getCategories(): Observable<Category[]>
   getCategory(id: number): Observable<Category>
   createCategory(category: Partial<Category>): Observable<Category>
   updateCategory(id: number, category: Category): Observable<Category>
   deleteCategory(id: number): Observable<void>
   ```

---

## 🛤️ 5. Routing

1. Define routes in `app.routes.ts`:

   ```ts
   import { Routes } from '@angular/router';
   import { CategoryList } from './components/category-list/category-list';
   import { CategoryCreate } from './components/category-create/category-create';
   import { CategoryEditComponent } from './components/category-edit/category-edit.component';
   import { CategoryDeleteComponent } from './components/category-delete/category-delete.component';

   export const routes: Routes = [
     { path: 'categories', component: CategoryList },
     { path: 'categories/create', component: CategoryCreate },
     { path: 'categories/edit/:id', component: CategoryEditComponent },
     { path: 'categories/delete/:id', component: CategoryDeleteComponent },
     { path: '', redirectTo: 'categories', pathMatch: 'full' },
     { path: '**', redirectTo: 'categories' }
   ];
   ```

2. In `app.component.html`, add:

   ```html
   <router-outlet></router-outlet>
   ```

   ⚠️ **Pitfall**: Without this, routes won’t render!

---

## 📝 6. Component Logic

- **Create Component (`category-create`)**  
  - Reactive form with validation (`Validators.required`, `Validators.maxLength(50)`).  
  - On submit, call `createCategory()` then navigate back to `/categories`.

- **Edit Component (`category-edit`)**  
  - Load category by `id` from route.  
  - Pre-fill form with `patchValue`.  
  - Use spread operator `...this.form.getRawValue()` to merge updates.  

- **Delete Component (`category-delete`)**  
  - Load category by `id`.  
  - Show confirmation prompt.  
  - Call `deleteCategory()` then navigate back.

---

## 🎨 7. Styling

- **Global styles** → `src/styles.css`  
  Example:
  ```css
  body {
    font-family: Arial, sans-serif;
    margin: 0;
    background-color: #f7f7f7;
  }
  ```

- **Component styles** → `.css` files co-located with each component.  
  ⚠️ Angular scopes these automatically (`body[_ngcontent-xxx]`), so use `styles.css` for true globals.

---

## ⚠️ Common Pitfalls

- Use `styleUrls` (plural) in `@Component`.  
- Use `[routerLink]` not plain `href` for Angular navigation.  
- Define the `/categories/create` route **before** wildcard redirects.  
- Always include `<router-outlet></router-outlet>` in your root template.  

---

✅ With this setup, you have a complete Angular client with **List, Create, Edit, and Delete** functionality against your ASP.NET Web API.

---

## 📊 Diagram

![Angular CRUD Flow](angular_crud_flow.png)
