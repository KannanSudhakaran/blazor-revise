# Correct Lifecycle Hook Usage in Blazor

## simple example to show the lifecycle methods

```C#
@page "/lifecycle"

<h3>Lifecycle Methods</h3>

<p>Check the console for lifecycle method calls.</p>

<button @onclick="OnButtonClick">Click Me</button>
<p>@DateTime.Now.ToString()</p>
@code {
    protected override void OnInitialized()
    {
        Console.WriteLine("OnInitialized called");
    }

    private void OnButtonClick()
    {
        Console.WriteLine("Button clicked");
    }
    

    protected override async Task OnParametersSetAsync()
    {
        Console.WriteLine("OnParametersSetAsync called");
    }

    protected override void OnAfterRender(bool firstRender)
    {
        if (firstRender)
        {
            Console.WriteLine("OnAfterRender called");
        }
    }
}
```
## Explanation of Lifecycle Methods

- `OnInitialized`: Called when the component is initialized. Use this method to perform any setup tasks, such as fetching data.
- `OnParametersSetAsync`: Called when component parameters are set. This is a good place to respond to changes in parameters.
- `OnAfterRender`: Called after the component has rendered. Use this method to perform any actions that require the component to be fully rendered, such as interacting with JavaScript.

## Example to show usage of ShouldRender

```C#
@page "/lifecycle"

<h3>Lifecycle Methods</h3>

<p>Check the console for lifecycle method calls.</p>

@code {
    protected override bool ShouldRender()
    {
        Console.WriteLine("ShouldRender called");
        return true; // Return true to allow rendering, false to prevent it
    }
}
```
## Explanation of ShouldRender

- `ShouldRender`: Called to determine if the component should re-render. This method is useful for optimizing performance by preventing unnecessary renders. Return `true` to allow rendering, or `false` to prevent it.

## A demonstration to prevent unnecessary renders

```C#
@page "/lifecycle"

<h3>Lifecycle Methods</h3>

<p>Check the console for lifecycle method calls.</p>

@code {
    private int _counter;

    protected override bool ShouldRender()
    {
        Console.WriteLine("ShouldRender called");
        return _counter % 2 == 0; // Only render on even counts
    }
}
```
- `ShouldRender`: In this example, the component will only re-render when the `_counter` is even. This can help improve performance by reducing the number of renders.


# Notes
 - Rendering mode need to be specified to get result of AfterRender method
 - In static side rendering, the AfterRender method will not be called.
- Also OnInitalized was called twice in deveopment vs production.
- To demonstrated instead of Console.WriteLine,you can add all items into a list and display them in the UI. `So the OnInitialized method will be displayed only once in list entry`

- The onAfterRender `will not be initially displayed in the list`.As it is called after the component has rendered.

- Parameter passing can be done thourgh `[]` syntax and not via the url parameter. This way the parent counter value changes child's `OnParameterSEt` will be called.



