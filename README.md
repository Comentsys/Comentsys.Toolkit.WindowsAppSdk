# Comentsys.Toolkit.WindowsAppSdk

**Comentsys.Toolkit.WindowsAppSdk** is a **Toolkit** with **Controls**, **Converters** and **Extensions** for **Windows App SDK** and uses **Comentsys.Toolkit**.

## Change Log

### Version 1.0.0

- Initial Release

## Asset

`Asset` can be used to represent an `AssetResource` visually which can be set with the **Property** for `AssetResource` in a **Windows App SDK** based Application.

### AssetResource

Asset Resource

## Card

`Card` will display a **Playing Card** for card-based games such as **Blackjack**, **Poket** and more. You can customise the `Back` of a `Card` using any `Brush` and can set the `Value` from *0* which will display the `Back` to between *1* and *52* to represent each **Suit** and **Card**.

### Back

Card Back

### Value

Card Value

## Dialog

`Dialog` makes it easy work with `ContentDialog` and avoid pitfalls and common errors when using them supporting both **Confirmation** and just **Showing** any **Dialogs**.

### Constructor(root, title)

Constructor

| Name | Description |
| ---- | ----------- |
| `root` | `Microsoft.UI.Xaml.XamlRoot`<br>Xaml Root |
| `title` | `System.String?`<br>Title |

### ConfirmAsync(content, primaryButtonText, secondaryButtonText, title)

Confirm

| Name | Description |
| ---- | ----------- |
| `content` | *`System.Object`*<br>Content |
| `primaryButtonText` | `System.String`<br>Primary Button Text |
| `secondaryButtonText` | `System.String`<br>Secondary Button Text |
| `title?` | `System.String`<br>Override Title |

#### Returns

True if Primary Button Selected False if not

### ConfirmAsync(content, primaryButtonText, secondaryButtonText, title)

Confirm

| Name | Description |
| ---- | ----------- |
| `content` | `System.String`<br>Content |
| `primaryButtonText` | `System.String`<br>Primary Button Text |
| `secondaryButtonText` | `System.String`<br>Secondary Button Text |
| `title` | `System.String?`<br>Override Title |

#### Returns

True if Primary Button Selected False if not

### Show(content, primaryButtonText, title)

Show

| Name | Description |
| ---- | ----------- |
| `content` | `System.Object`<br>Content |
| `primaryButtonText` | `System.String`<br>Primary Button Text |
| `title` | `System.String`<br>Override Title |

### Show(content, primaryButtonText, title)

Show

| Name | Description |
| ---- | ----------- |
| `content` | `System.String`<br>Content |
| `primaryButtonText` | *System.String*<br>Primary Button Text |
| `title` | `System.String`<br>Override Title |

## Dice

`Dice` can display values by seting the `Value` from *0* to display no value to between *1* and *6* to represent the **Face** a **Dice** or **Die**. You can customise the `Foreground` of a `Dice` using any `Brush` which will change the **Colour** of the **Pips** use on the **Face** of the **Dice**.

### Foreground

Dice Foreground

### Value

Dice Value

## Piece

`Piece` can be used to represent items in **Games** in either a **Square** or **Circle** and can contain a `Value` which can be a short `string`, the outline or `Stroke` can be set, along with the `Foreground` for the `Value` and the `Fill` of the `Piece`.

### Fill

Piece Fill

### Foreground

Piece Foreground

### IsSquare

Piece Is Square?

### Stroke

Piece Stroke

### Value

Piece Value

## Sector

`Sector` can be used to represent a portion or **Arc** section of a **Circle** as needed. The `Start` and `Finish` position of the `Sector` can be set, along with the `Radius` and `Hole` which allows for a variety of combinations for display, it also supports all the values of a `Path` for a `Shape`.

### Finish

Sector Finish

### Hole

Sector Hole

### Radius

Sector Radius

### Start

Sector Start

## BoolToVisibilityConverter

`BoolToVisibilityConverter` implements the **Interface** for `IValueConverter` and supports conversion of an `object` to a `bool` for use with **Binding**. 

### Convert(value, targetType, parameter, language)

Convert

| Name | Description |
| ---- | ----------- |
| `value` | `System.Object`<br>Bool Value |
| `targetType` | `System.Type`<br>Target Type |
| `parameter` | `System.Object`<br>Parameter |
| `language` | `System.String`<br>Language |

#### Returns

Visiblity

### ConvertBack(value, targetType, parameter, language)

Convert Back

| Name | Description |
| ---- | ----------- |
| `value` | `System.Object`<br>Value |
| `targetType` | `System.Type`<br>Target Type |
| `parameter` | `System.Object`<br>Parameter |
| `language` | `System.String`<br>Language |

*System.NotImplementedException:* 

## StringFormatConverter

`StringFormatConverter` implements the **Interface** for `IValueConverter` and supports **Formatting** of an `object` that is a `string` for use with **Binding**.

### Convert(value, targetType, parameter, language)

Convert

| Name | Description |
| ---- | ----------- |
| `value` | `System.Object`<br>Bool Value |
| `targetType` | `System.Type`<br>Target Type |
| `parameter` | `System.Object`<br>String Format |
| `language` | `System.String`<br>Language |

#### Returns

Formatted String

### ConvertBack(value, targetType, parameter, language)

Convert Back

| Name | Description |
| ---- | ----------- |
| `value` | `System.Object`<br>Bool Value |
| `targetType` | `System.Type`<br>Target Type |
| `parameter` | `System.Object`<br>String Format |
| `language` | `System.String`<br>Language |

*System.NotImplementedException:* 

## Extensions

**Comentsys.Toolkit.WindowsAppSdk** contains some useful **Methods** to **Extend** behaviour including **Converting** to or from a **Windows Colour** to a **Drawing Colour** and one for `AssetResource` to get an `ImageSource` for an **Asset Resource**.

### AsDrawingColor(color)

As Drawing Color

| Name | Description |
| ---- | ----------- |
| color | `Windows.UI.Color`<br>Windows Color |

#### Returns

Drawing Color

### AsImageSourceAsync(assetResource)

As Image Source

| Name | Description |
| ---- | ----------- |
| `assetResource` | `Comentsys.Toolkit.AssetResource`<br>Asset Resource |

#### Returns

Image Source

### AsWindowsColor(color)

As Windows Color

| Name | Description |
| ---- | ----------- |
| `color` | `System.Drawing.Color`<br>Drawing Color |

## Licence

```
The MIT License (MIT)

Copyright (c) 2022 Comentsys

Permission is hereby granted, free of charge, to any person obtaining a copy of this software and associated documentation files (the “Software”), to deal in the Software without restriction, including without limitation the rights to use, copy, modify, merge, publish, distribute, sublicense, and/or sell copies of the Software, and to permit persons to whom the Software is furnished to do so, subject to the following conditions:

The above copyright notice and this permission notice shall be included in all copies or substantial portions of the Software.

THE SOFTWARE IS PROVIDED “AS IS”, WITHOUT WARRANTY OF ANY KIND, EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING
```