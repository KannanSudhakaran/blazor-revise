# Cascading Parameters in Blazor

Cascading parameters in Blazor allow you to pass data down the component hierarchy without having to explicitly pass them through each level. This is particularly useful for sharing common data, such as themes, user information, or settings, across multiple components.

**Note : Only Type matters  data type doesnot matter for Cascading Parameters**

## How to Use Cascading Parameters

1. **Define a Cascading Value**: In a parent component, you can define a cascading value using the `CascadingValue` component. This component wraps the part of the UI where the value should be available.

   ```xml
   <CascadingValue Value="myValue">
       <ChildComponent />
   </CascadingValue>
   ```
```C#
@code {
    private string myValue = "SomeValue";
}

```

2. **Consume the Cascading Value**: In a child component, you can consume the cascading value using the `[CascadingParameter]` attribute.

   ```C#
   @code {
       [CascadingParameter]
       public string MyValue { get; set; }
   }
   ```

## Example

Here's a simple example demonstrating cascading parameters:

```xml
<!-- ParentComponent.razor -->
<CascadingValue Value="CurrentTheme">
    <ChildComponent />
</CascadingValue>

<!-- ChildComponent.razor -->
@code {
    [CascadingParameter]
    public string CurrentTheme { get; set; }
}
```

In this example, the `CurrentTheme` value is made available to `ChildComponent` without having to pass it explicitly as a parameter.
