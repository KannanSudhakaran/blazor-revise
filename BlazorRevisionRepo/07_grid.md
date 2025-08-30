# Learn Showing tables of data with QuickGrid

## Step-by-Step: Creating a QuickGrid in Blazor

QuickGrid is a Blazor component for displaying tabular data efficiently. Here’s how to create a simple QuickGrid:

### 1. Install the QuickGrid NuGet package
Run this command in your project folder:
```
dotnet add package Microsoft.AspNetCore.Components.QuickGrid
```

### 2. Add sample data
Define a simple data model and sample data in your component:
```razor
@code {
	 public class Person
 {
     public int Id { get; set; }
     public string Name { get; set; } = string.Empty;
     public int Age { get; set; }
 }

 private IQueryable<Person> people = new List<Person>()
 {
     new Person { Id = 1, Name = "Alice", Age = 30 },
     new Person { Id = 2, Name = "Bob", Age = 25 },
     new Person { Id = 3, Name = "Charlie", Age = 35 }
 }.AsQueryable();
}
```

### 3. Add the QuickGrid to your page
Use the `<QuickGrid>` component to display your data:
```razor
<QuickGrid TItem="Person" Items="people">
    <PropertyColumn Property="@(p => p.Id)" Title="ID" />
    <PropertyColumn Property="@(p => p.Name)" Title="Name" />
    <PropertyColumn Property="@(p => p.Age)" Title="Age" />
</QuickGrid>
```

### 4. Run your app
Navigate to the page and you’ll see a table displaying your data.

---

**Tip:**
- You can add sorting, paging, and custom columns for more advanced scenarios.
- QuickGrid is optimized for performance and works well with large datasets.