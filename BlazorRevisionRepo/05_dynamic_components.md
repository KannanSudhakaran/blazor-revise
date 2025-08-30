## Example: Building a Plugin System with Dynamic Components in Blazor

Blazor allows you to build a flexible plugin system using dynamic components. Here’s how you can do it step by step:

### 1. Define Plugin Components
Each plugin is a Blazor component. For example:

**WeatherWidget.razor**
```razor
<h4>Weather Widget</h4>
<p>Today's weather: Sunny</p>
```

**NewsWidget.razor**
```razor
<h4>News Widget</h4>
<p>Latest news: Blazor is awesome!</p>
```

### 2. Register Plugins
Maintain a list of plugin component types in your main page or dashboard.

### 3. Render Plugins Dynamically
Use Blazor’s `DynamicComponent` to render each plugin based on its type.

**Dashboard.razor**
```razor
@page "/dashboard"

<h3>Dashboard</h3>
<button @onclick="AddWeatherWidget">Add Weather Widget</button>
<button @onclick="AddNewsWidget">Add News Widget</button>

<div>
	@foreach (var pluginType in _plugins)
	{
		<DynamicComponent Type="@pluginType" />
	}
</div>

@code {
	private List<Type> _plugins = new();

	private void AddWeatherWidget()
	{
		_plugins.Add(typeof(WeatherWidget));
	}

	private void AddNewsWidget()
	{
		_plugins.Add(typeof(NewsWidget));
	}
}
```

### How it works
- Clicking "Add Weather Widget" adds and renders the WeatherWidget component.
- Clicking "Add News Widget" adds and renders the NewsWidget component.
- You can add any number of plugins, and they will be displayed dynamically.

This approach lets you build a dashboard or plugin system where users can choose which widgets (components) to display, and Blazor renders them dynamically using `DynamicComponent`.

