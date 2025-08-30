# •	Smart and Dumb Components
#
---

## 1. What are Smart and Dumb Components?

- **Smart Component**: Handles data fetching, business logic, and state management. Passes data to child components.
- **Dumb Component**: Only displays data received via parameters. No business logic.

---

## 2. Example Scenario

Suppose you want to display a list of users.  
- The Smart Component fetches the user list.
- The Dumb Component displays the list.

---

### Step 1: Create a Dumb Component (`UserList.razor`)

```razor
@* UserList.razor *@
@code {
	[Parameter]
	public List<string> Users { get; set; }
}

<ul>
	@foreach (var user in Users)
	{
		<li>@user</li>
	}
</ul>
```

- Accepts a list of users via `[Parameter]`.
- Only responsible for rendering.

---

### Step 2: Create a Smart Component (`UserPage.razor`)

```razor
@* UserPage.razor *@
@code {
	private List<string> users = new() { "Alice", "Bob", "Charlie" };
}

<h3>User List</h3>
<UserList Users="users" />
```

- Handles the data (`users` list).
- Passes data to `UserList` (the dumb component).

---

### Step 3: Use the Smart Component in Your App

Add `<UserPage />` to your main layout or page.

---

## Summary Table

| Component   | Role                | Example File      |
|-------------|---------------------|------------------|
| Smart       | Data/Logic/State    | UserPage.razor   |
| Dumb        | Display/Render only | UserList.razor   |

---

Would you like code for more advanced scenarios (e.g., events, two-way binding)?