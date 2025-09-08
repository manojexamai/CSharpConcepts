Angular Project to List all Categories

01. Add the Angular TS Client Project
02. Open View > Terminal.  And either in "Power Shell" OR "Developer Command Prompt" 
    navigate to the "Project" folder using the "CD" command.
03. Now add support for HttpClientModule in the application in the "src/app/app-module.ts" file:
        ...
        // Import the HttpClientModule class
        import { provideHttpClient } from '@angular/common/http';         
        ...
        providers: [
            ...
            provideHttpClient()
        ]
04. Next, add the Service to the DI container. Run the following command: 
        > ng generate service services/category
    This will create the following two files in the "services" folder:
        src/app/services/category.spec.ts
        src/app/services/category.ts
05. Rename the "category.ts" file to "category.service.ts" 
    And move the interface to its own file "category.model.ts".
06. Next, add the Component to display the list of categories.
    In the Terminal Window, after navigating to the "Project" folder, run the following command:
        > ng generate component components/category-list --standalone=true
    This will generate the StandAlone Component by:
        creating the following files:
            src/app/components/category-list/category-list.spec.ts
            src/app/components/category-list/category-list.ts
            src/app/components/category-list/category-list.css
            src/app/components/category-list/category-list.html
        And, registers the list component in the "src/app/app-module.ts" file.
            Make sure that the component is registered in the "imports" section, and not in the "declarations" section.

06. Next, fetch the categories in the "category-list.ts" component file.
07. And update the "category-list.html" file to display the data.
08. Now, update the "category-list.css" file 
09. Finally, in the main app component file - "src/app/app.ts", 
    replace the templateUrl with the customized template to show the category-list component.
10. Configure the Routing in the "app-routing-module.ts" file

================================================================================================

11. Add the components for create, edit and delete:
    > ng generate component components/category-create --standalone=true
        CREATE src/app/components/category-create/category-create.spec.ts
        CREATE src/app/components/category-create/category-create.ts
        CREATE src/app/components/category-create/category-create.css
        CREATE src/app/components/category-create/category-create.html
    > ng generate component components/category-edit --standalone=true
        CREATE src/app/components/category-edit/category-edit.spec.ts
        CREATE src/app/components/category-edit/category-edit.ts
        CREATE src/app/components/category-edit/category-edit.css
        CREATE src/app/components/category-edit/category-edit.html
    > ng generate component components/category-delete --standalone=true
        CREATE src/app/components/category-delete/category-delete.spec.ts
        CREATE src/app/components/category-delete/category-delete.ts
        CREATE src/app/components/category-delete/category-delete.css
        CREATE src/app/components/category-delete/category-delete.html
12. Register all the API service methods in the "category.service.ts" file.
13. Register the Routes for the components in "app-routing.module.ts" file. 
14. In the "category-list.ts" module file, register the Routermodule.
15. In the "category-list.html" file, provide the route links.
16. In the app component "app.ts" file, register the router outlet by adding the following line in the template:
        <router-outlet></router-outlet>
17. Now, complete the create component "category-create.ts" and its template "category-create.html" files.
18. And similarly, complete the edit and delete components.
19. Global styles can be applied at "styles.css" file.  Like:
        body { }
    Component-level styles are finally rendered like this:
        body[_ngcontent-abc] { }
    Also make sure that you use "styleUrls" (plural) in components, not "styleUrl"!

================================================================================================

Standalone Components (Angular 15+)
    A component can exist without being declared in any NgModule.
    Instead, you mark it with standalone: true.

    To create the component:
        > ng generate component components/category-list --standalone
        OR
        > ng generate component components/category-list --standalone=true

    Whatever it needs (e.g. CommonModule, FormsModule, other standalone components), 
    it is imported directly into the component itself.

    Example:
        @Component({
          selector: 'app-my',
          standalone: true,                             // makes it standalone
          imports: [CommonModule, FormsModule],
          template: `...`
        })
        export class MyComponent {}

    Now the component is self-contained — it declares its own dependencies.
    To use it, just import it:
        @NgModule({
          imports: [BrowserModule, MyComponent],        // no declarations needed
          bootstrap: [AppComponent]
        })
        export class AppModule {}


Non-standalone Components (Traditional Angular, pre-v15)

    A component must belong to an NgModule, and is put inside the declarations array of an @NgModule.
    Directives, pipes, and other components are made available through NgModule imports (like CommonModule).

    To create the component:
        > ng generate component components/category-list --standalone=false

    Typical structure looks like:
        @NgModule({
          declarations: [MyComponent],                              // must be declared here
          imports: [CommonModule, FormsModule],
          bootstrap: [AppComponent]
        })
        export class AppModule {}

    So the component is not self-contained — it relies on a module to "host" it.

================================================================================================

To learn more: 

	Create an ASP.NET Core app with Angular in Visual Studio
	https://learn.microsoft.com/en-us/visualstudio/javascript/tutorial-asp-net-core-with-angular?view=vs-2022

	"Angular App" (with TypeScript)
	https://learn.microsoft.com/en-us/visualstudio/javascript/tutorial-create-angular-app?view=vs-2022

	Angular Application with .Net Core Web API 
	(C#, Angular,TypeScript)
	Part 1 to 4: https://www.youtube.com/watch?v=0DBy2NHtmu4

	Google for "Angular and ASP.NET Core" project:
