# Canvas and Open GL Stock and Financial Charts

Generic real-time charts for WPF apps. 

The main purpose of this app is to be used as a charting tool for real-time financial applications, e.g. backtesters for trading strategies. 
Here is [the most comprehensive guide](https://github.com/artemiusgreat/Csharp-Data-Visualization) dedicated to charting in .NET that I have seen so far. 
Nevertheless, trying various options from that guide I wasn't able to find anything flexible enough for my needs, so created my own. 

# Drawing methods

Currently available controls.

* CanvasControl - extended WPF `Canvas` control exposing `DrawingContext` used with `Shapes` and `Geometries`
* CanvasImageControl - a wrapper around [SkiaSharp](https://github.com/mono/SkiaSharp) and Open GL 

In order to add a different type of panel, e.g. `GDI+`, you need to implement `ICanvasControl` interface.

# Chart types 

At the moment, there are four built-in chart types. 

* Line - line 
* Bar - polygon
* Area - polygon
* Candle - OHLC box, a mix of a line and a rectangle polygon

If there is a need to create a new chart type, then you need to implement `IShape` interface. 

# Pan and Zoom 

The chart is completely data-centric, thus in order to scale the chart you need to change the data source. 
By default, the chart displays last 100 data points, as defined in `IndexCount` property. 

```
MinIndex = Items.Count - IndexCount
MaxIndex = Items.Count
```

To pan the chart to the left, subtract arbitrary value from both `MinIndex` and `MaxIndex`. 

```
MinIndex -= 1
MaxIndex -= 1
```

To pan the chart to the left, do the opposite. 

```
MinIndex += 1
MaxIndex += 1
```

To zoom in, increase `MinIndex` and decrease `MaxIndex` to decrease number of visible points. 

```
MinIndex += 1
MaxIndex -= 1
```

To zoom out, do the opposite. 

```
MinIndex -= 1
MaxIndex += 1
```

# Data source sample

To simplify sycnhronization of multiple charts, data source has format of a list where each entry point has a time stamp and a set of Areas and Series that will be rendered in the relevant viewport. 

```
[
  DateTime
  {
    Area A
    {
      Line Series => double,
      Candle Series => OHLC
    },
    Area B 
    {
      Line Series => double,
      Line Series => double
    },
    Area C 
    {
      Bar Series => double
    }
  }, 
  DateTime,
  DateTime,
  DateTime
]

```

* **Area** is a viewport, an actual chart, each viewport can show several types of series, e.g. a mix of candles and lines.
* **Series** is a single chart type to be displayed in the viewport, e.g. lines. 
* **Model** is a data point of `dynamic` type, can accept different type of inputs, e.g. double or OHLC box.

At this moment, `Painter` supports only horizontal orientation, so the axis X is used as an index scale that picks data points from the source list and axis Y is a value scale that represents the actual value of each data point. 

# Preview 

![](Screens/Preview.png)
