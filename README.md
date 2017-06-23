# Xamarin.Cartography :iphone::triangular_ruler:

Using Cartography, you can set up your Auto Layout constraints in declarative code and without any stringly typing!

In short, it allows you to replace this:

<img src="/images/pirates2.png" align="right" height="280px" hspace="30px" vspace="30px">

```C#
AddConstraint(NSLayoutConstraint.Create(
    item: button1,
    attribute: .Right,
    relatedBy: .Equal,
    toItem: button2,
    attribute: .Left,
    multiplier: 1.0,
    constant: -12.0
));
```

with this

```C#
Cartography.Constrain(button1, button2, (button1, button2) => {
    button1.right == button2.left - 12;
});
```

## Usage

Call the `Constrain` function with your `UIView` or `NSView` instances as well
as a closure in which you declare the constraints between the different
attributes of your views:

```C#
Cartography.Constrain(view1, view2, (view1, view2) => {
    view1.width   == (view1.superview.width - 50) * 0.5;
    view2.width   == view1.width - 50;
    view1.height  == 40;
    view2.height  == view1.height;
    view1.centerX == view1.superview.centerX;
    view2.centerX == view1.centerX;

    view1.top >= view1.superview.top + 20;
    view2.top == view1.bottom + 20;
});
```

<img src="/images/pirates1.png" align="left" height="220px" hspace="20px" vspace="10px">

For every view on the left hand side of an equality or inequality operator,
Cartography will automatically set its
`translatesAutoresizingMaskIntoConstraints` property to `false`.

If the view is
not controlled by you–for example _if it belongs to a Apple-provided
`UIViewController` class_–you should take appropriate care when declaring its
constraints.

<br><br>

## Replacing constraints

You can capture multiple constraints in a group to then replace them with new
constraints at a later point.

```C#
Cartography.Constrain(view, (view) => {
    view.width  == 100;
    view.height == 100;
});

var group = new ConstraintGroup();

// Attach `view` to the top left corner of its superview
Layout.Constrain(view, replace: group, (view) => {
    view.top  == view.superview.top;
    view.left == view.superview.left;
});

/* Later */

// Move the view to the bottom right corner of its superview
Layout.Constrain(view, replace: group, (view) => {
    view.bottom == view.superview.bottom;
    view.right  == view.superview.right;
});

UIView.AnimateWithDuration(0.5, animations: view.layoutIfNeeded);
```

For convenience, the `Constrain` functions also returns `ConstraintGroup`
instances:

```C#
var group = Cartography.Constrain(button, (button) => {
    button.width  == 100;
    button.height == 400;
});
```

## Supported attributes


Cartography supports all built-in attributes as of iOS 8 and OS X 10.9, those are:

<img src="/images/pirates3.png" align="right" height="400px" hspace="20px" vspace="100px">

- `width`
- `height`
- `top`
- `right`
- `bottom`
- `left`
- `leading`
- `trailing`
- `centerX`
- `centerY`
- `baseline`

as well as the iOS specific

- `firstBaseline`
- `leftMargin`
- `rightMargin`
- `topMargin`
- `bottomMargin`
- `leadingMargin`
- `trailingMargin`
- `centerXWithinMargins`
- `centerYWithinMargins`
- `edgesWithinMargins`

These can be further refined using the following operators: `*`, `/`, `+` and
`-`.

Additionally, it supports convenient compound attributes that allow you to
assign multiple attributes at once:

```C#
Layout.Constrain(view, (view) => {
    view.size   == view.superview.size / 2;
    view.center == view.superview.center;
});
```

```C#
Layout.Constrain(view, (view) => {
    view.edges == new UIEdgesInset(view.superview.edges, 20, 20, 40, 20);
});
```

### Aligning multiple view

If you need to align multiple views by a common edge, you can use the `align`
functions:

```C#
Layout.Constrain(view1, view2, view3, (view1, view2, view3) => {
    align(top: view1, view2, view3);
});
```

Which is equivalent to `view1.top == view2.top; view2.top == view3.top`. Similar
variants exist for `top`, `right` `bottom`, `left`, `leading`, `trailing`,
`centerX`, `centerY` and `baseline`.

### Distributing views evenly

For distributing multiple views, either horizontally or vertically, you can use
the `distribute` functions:

```C#
constrain(view1, view2, view3) { view1, view2, view3 in
    distribute(by: 10, horizontally: view1, view2, view3)
}
```

Which is equivalent to `view1.trailing == view2.leading - 10; view2.trailing == view3.leading - 10`.

## Setting priorities

You can set the priorities of your constraints using the `~` operator:

```C#
constrain(view) { view in
    view.width  >= 200 ~ 100
    view.height >= 200 ~ 100
}
```

## Capturing constraints

Since the `==`, `>=`, `<=` and `~` emit `NSLayoutConstraint` instances, you can
capture their results if you need to refer to the layout constraints at a later
time:

```C#
var width: NSLayoutConstraint?

constrain(view) { view in
    width = (view.width == 200 ~ 100)
}
```

Note that declaring compound attributes returns multiple constraints at once:

```C#
var constraints: [NSLayoutConstraint]?

constrain(view) { view in
    constraints = (view.size == view.superview!.size ~ 100)
}
```

## Documentation

Read the documentation [here](http://robb.github.io/Cartography/). For more information, see the [gh-pages](https://github.com/robb/Cartography/tree/gh-pages) branch.

## About Cartography

Xamarin.Cartography is a complete C# port written by [Jairo Tylera][me].

Cartography was built by [Robb Böhnke][me] and was inspired by the excellent
[FLKAutoLayout] by [Florian Kugler][florian].

[flkautolayout]: https://github.com/floriankugler/FLKAutoLayout
[florian]:       https://github.com/floriankugler
[me]:            http://jairo.me
