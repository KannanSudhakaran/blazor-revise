# • Managing Authentication State in blazor

## Step-by-Step Example: Managing Authentication State in Blazor

### 1. Create a Service to Hold Authentication State

```csharp
public class AuthService
{
    public bool IsAuthenticated { get; private set; }
    public string? UserName { get; private set; }

    public void Login(string userName)
    {
        IsAuthenticated = true;
        UserName = userName;
    }

    public void Logout()
    {
        IsAuthenticated = false;
        UserName = null;
    }
}
```

### 2. Register the Service in `Program.cs`

Add this line to your DI container:

```csharp
builder.Services.AddSingleton<AuthService>();
```

### 3. Inject and Use the Service in a Component

In your Razor component (e.g., `Pages/Login.razor`):

```razor
@inject AuthService AuthService

@if (!AuthService.IsAuthenticated)
{
    <button @onclick="Login">Login</button>
}
else
{
    <p>Welcome, @AuthService.UserName!</p>
    <button @onclick="Logout">Logout</button>
}

@code {
    void Login()
    {
        AuthService.Login("Alice");
    }

    void Logout()
    {
        AuthService.Logout();
    }
}
```

### 4. Show/Hide UI Based on Authentication State

You can use `AuthService.IsAuthenticated` anywhere to show/hide content.

---

**Summary:**  
1. Create a service to store authentication info.  
2. Register it for dependency injection.  
3. Inject and use it in your components to manage login/logout and show/hide UI.