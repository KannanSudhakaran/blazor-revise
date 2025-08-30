# Error Boundaries in Blazor

Error boundaries allow you to catch and display errors from child components, preventing the entire app from crashing.

## Step-by-Step: Custom Error Boundary Example

### 1. Create a Custom Error Boundary Component

Create a new file called `CustomErrorBoundary.razor`:

```razor
@inherits ErrorBoundary

<div>
    @if (CurrentError != null)
    {
        <h3 style="color:red;">Something went wrong!</h3>
        <p>@CurrentError.Message</p>
        <button @onclick="OnRecover">Try Again</button>
    }
    else
    {
        @ChildContent
    }
</div>

@code {
    private void OnRecover()
    {
        base.Recover(); // Reset error state
    }
}
```

### 2. Create a Problematic Component

Create a new file called `ProblematicComponent.razor`:

```razor
<button @onclick="ThrowError">Throw Error</button>

@code {
    private void ThrowError()
    {
        throw new InvalidOperationException("This is a test error!");
    }
}
```

### 3. Use the Error Boundary in a Page

In your page (e.g., `Pages/ErrorBoundaryDemo.razor`):

```razor
@page "/error-boundary-demo"

<h3>Error Boundary Demo</h3>

<CustomErrorBoundary>
    <ProblematicComponent />
</CustomErrorBoundary>
```

### 4. Run Your App

Navigate to `/error-boundary-demo` and click the "Throw Error" button. The error boundary will catch the exception and display the fallback UI with a "Try Again" button.

---

**Tip:**
- You can wrap any component with your custom error boundary to isolate errors.
- The `Try Again` button resets the error state and lets you retry rendering the child component.
