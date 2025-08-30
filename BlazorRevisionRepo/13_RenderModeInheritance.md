# RenderMode Inheritance in blazor

## Step-by-Step Example: RenderMode Inheritance in Blazor

### 1. What is RenderMode?
RenderMode in Blazor determines how a component is rendered:
- `Server`: Interactive via SignalR (Blazor Server)
- `WebAssembly`: Runs in browser (Blazor WASM)
- `Static`: No interactivity, just HTML

### 2. Set RenderMode at App Level
In your `App.razor` or `Program.cs`, you can set a default RenderMode for all components:

```csharp
// In Program.cs (.NET 8+)
builder.RootComponents.Add<App>("#app", RenderMode.Server);
```

### 3. Override RenderMode at Component Level
You can override the RenderMode for specific components:

```razor
<!-- In MainLayout.razor -->
<SomeComponent render-mode="WebAssembly" />
```

### 4. Inheritance Behavior
If you don’t specify a RenderMode for a child component, it inherits from its parent or the app default.

Example:
```razor
<!-- ParentComponent.razor -->
@* This parent uses Server mode *@
<ChildComponent /> <!-- Child will inherit Server mode unless overridden -->
```

### 5. Demo Example
1. Set default RenderMode to `Server` in `Program.cs`.
2. Create `ParentComponent.razor`:
	```razor
	@* No render-mode specified, inherits Server *@
	<ChildComponent />
	```
3. Create `ChildComponent.razor`:
	```razor
	@* No render-mode specified, inherits from ParentComponent *@
	<p>This is the child component.</p>
	```
4. Now, override in Parent:
	```razor
	<ChildComponent render-mode="WebAssembly" />
	```
	Now, `ChildComponent` uses WebAssembly, even though Parent uses Server.

### 6. Summary
- If not specified, RenderMode is inherited.
- You can override RenderMode per component.
- Useful for mixing interactive and static content.

---

## Q&A: Can a child override and make itself static implicitly?

**Q:** Can a child component override the inherited RenderMode and set itself to Static, even if the parent or app default is Server or WebAssembly?

**A:** Yes, a child component in Blazor can override the inherited RenderMode and explicitly set itself to `Static`, regardless of the parent’s RenderMode. For example:

```razor
<!-- ParentComponent.razor -->
<ChildComponent /> <!-- Inherits parent's RenderMode unless overridden -->

<!-- ChildComponent.razor -->
@rendermode Static
<p>This child is rendered as static HTML, no interactivity.</p>
```

This means the child will be rendered as static HTML, even if the parent or app default is Server or WebAssembly. The override is explicit in the child component.


