# Virtualization in Blazor

## What is Virtualization?

Virtualization is a technique used to efficiently render large lists or collections by only displaying the items that are currently visible on the screen. This improves performance and reduces memory usage, especially when dealing with thousands of items.

## Simple Example: Virtualize a List

Blazor provides the `<Virtualize>` component for virtualization. Here’s a simple demonstration:

```razor
@page "/virtualization-demo"

<h3>Virtualization Demo</h3>

<Virtualize Items="items" ItemSize="40">
	<ItemContent>
		@(context =>
			<div style="height:40px; border-bottom:1px solid #ccc; padding:8px;">
				Item: @context
			</div>
		)
	</ItemContent>
</Virtualize>

@code {
	private List<string> items = Enumerable.Range(1, 10000)
		.Select(i => $"Item {i}").ToList();
}
```

## How it works
- Only the items visible in the viewport are rendered.
- As you scroll, Blazor automatically loads and displays more items.
- This keeps the UI fast and responsive, even with very large lists.

You can adjust `ItemSize` to match the height of your items for best performance.



