
# Handling Location Changing Events in Blazor

Blazor allows you to intercept and handle navigation events before the location actually changes. This is useful for scenarios like showing a confirmation dialog, saving unsaved data, or preventing navigation under certain conditions.

## Example Scenario

Suppose you have a form with unsaved changes. If the user tries to navigate away, you want to warn them and optionally cancel the navigation.

## Step-by-Step: Handling Location Changing Events

### 1. Inject NavigationManager and Subscribe to LocationChanging

In your component, inject `NavigationManager` and subscribe to the `LocationChanging` event:

```razor
@page "/navigation2"
@rendermode InteractiveServer
@inject NavigationManager Navigation

<h3>Location Changing Events Demo</h3>

<button @onclick="MakeUnsavedChange">Make Unsaved Change</button>
<button @onclick="MakeSavedChange">Make Saved Change</button>
<p>@(hasUnsavedChanges ? "You have unsaved changes!" : "All changes saved.")</p>
<a @onclick="GoToHome" class="btn btn-outline-primary me-2">Go to Home</a>
<a @onclick="GotoCounter" class="btn btn-outline-primary">Go to Counter</a>


@code {
	private IDisposable? locationChangingRegistration;
	private void GotoCounter()
	{
		Navigation.NavigateTo("/counter");
	}

	private void GoToHome()
	{
		Navigation.NavigateTo("/");
	}

	private bool hasUnsavedChanges = false;

	protected override void OnInitialized()
	{
	 locationChangingRegistration=	Navigation.RegisterLocationChangingHandler(OnLocationChanging);
	}

	private void MakeUnsavedChange()
	{
		hasUnsavedChanges = true;
	}
	private void MakeSavedChange()
	{
		hasUnsavedChanges = false;
    }
	

	private async ValueTask OnLocationChanging(LocationChangingContext context)
	{
		if (hasUnsavedChanges)
		{
			bool userWantsToLeave = await JS.InvokeAsync<bool>("confirm",
				"You have unsaved changes. Do you really want to leave?");

			if (!userWantsToLeave)
			{
				context.PreventNavigation(); // Stop the navigation
			}
		}
	  //return ValueTask.CompletedTask;
	}

	

	[Inject] IJSRuntime JS { get; set; }

	public void Dispose()
	{
		// Clean up when component is destroyed
		locationChangingRegistration?.Dispose();
	}
}
```

### 2. How it works
- When the user tries to navigate away, the `OnLocationChanging` event is triggered.
- If there are unsaved changes, a confirmation dialog appears.
- If the user cancels, navigation is prevented.

### 3. Clean Up
Unsubscribe from the event in `Dispose` to avoid memory leaks.

---

**Tip:**
- You can use this pattern to implement custom navigation guards, save prompts, or analytics.
