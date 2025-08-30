# Building Component Library

Lets see step by step how to build a component library in Blazor.

## Steps to Create a Blazor Component Library

1. **Create a new Blazor project**
   - In Visual Studio or VS Code terminal, run:
     ```
     dotnet new blazorwasm -o BlazorApp
     ```

2. **Add a new razor library project**
  - ``Note: It must be a Razor Class Library``

   - Run:
     ```
     dotnet new razorclasslib -o MyRazorComponentLibrary
     ```

3. **Reference the class library in the Blazor project**
   - In the Blazor project folder, run:
     ```
     dotnet add reference ../MyComponentLibrary/MyComponentLibrary.csproj
     ```

4. **Create reusable components in the class library**
   - Add `.razor` files in `MyComponentLibrary` (e.g., `Alert.razor`, `Button.razor`).

   **Example: Alert.razor**
   ```C#
   <div class="alert alert-@Type">
       @Message
   </div>

   @code {
       [Parameter] public string Type { get; set; } = "info";
       [Parameter] public string Message { get; set; }
   }
   ```

**Example: Button.razor**
```C#
<button class="btn btn-@Color" @onclick="OnClick">
    @Text
</button>

@code {
    [Parameter] public string Color { get; set; } = "primary";
    [Parameter] public string Text { get; set; }
    [Parameter] public EventCallback OnClick { get; set; }
}
```
**Use the component in the Blazor project**

- Add a reference to the library in `_Imports.razor`:
```C#
@using MyComponentLibrary
```
Use the components in your pages:

```html
<Alert Type="success" Message="Operation completed successfully!" />
<Button Color="danger" Text="Delete" OnClick="@OnDelete" />
```

```C#
@code {
    void OnDelete() {
        // Handle delete action
    }
}
```
**Tips**

- You can add more reusable components (e.g., Card, Modal, Loader) to your library.
- Share styles via CSS files in the library.
- Publish the library as a NuGet package for reuse in other projects.




