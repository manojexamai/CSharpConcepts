01. Add the Angular TS Client Project
02. Open View > Terminal.  And either in "Power Shell" OR "Developer Command Prompt" 
    navigate to the "Project" folder using the "CD" command.
03. Next, add the Service to the DI container. Run the following command: 
        > ng generate service services/category
    This will create the following two files in the "services" folder:
        src/app/services/category.spec.ts
        src/app/services/category.ts
04. Rename the "category.ts" file to "category.service.ts" 
    And move the interface to its own file "category.model.ts".
04. Now add support for HttpClientModule in the application in the "src/app/app-module.ts" file:
        ...
        // Import the HttpClientModule class
        import { provideHttpClient } from '@angular/common/http';         
        ...
        providers: [
            ...
            provideHttpClient()
        ]
05. Next, add the Component to display the list of categories.
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
          declarations: [MyComponent],          // must be declared here
          imports: [CommonModule, FormsModule],
          bootstrap: [AppComponent]
        })
        export class AppModule {}

    So the component is not self-contained — it relies on a module to “host” it.
