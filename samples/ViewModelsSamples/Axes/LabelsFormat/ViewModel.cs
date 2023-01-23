﻿using CommunityToolkit.Mvvm.ComponentModel;
using LiveChartsCore;
using LiveChartsCore.SkiaSharpView;
using LiveChartsCore.SkiaSharpView.Painting;
using SkiaSharp;

namespace ViewModelsSamples.Axes.LabelsFormat;

[ObservableObject]
public partial class ViewModel
{
    public ISeries[] Series { get; set; } =
    {
        new ColumnSeries<double> { Values = new double[] { 426, 583, 104 } },
        new LineSeries<double>   { Values = new double[] { 200, 558, 458 }, Fill = null },
    };

    public Axis[] XAxes { get; set; } =
    {
        new Axis
        {
            Name = "Salesman",
            // Use the labels property for named or static labels // mark
            Labels = new string[] { "Sergio", "Lando", "Lewis" }, // mark
            LabelsRotation = 15,
            InLineNamePlacement = true,
            Position = LiveChartsCore.Measure.AxisPosition.End,
        }
    };

    public Axis[] YAxes { get; set; } =
    {
        new Axis
        {
            Name = "Salome",
            //NamePadding = new LiveChartsCore.Drawing.Padding(0, 15),

            LabelsPaint = new SolidColorPaint
            {
                Color = SKColors.Blue,
                FontFamily = "Times New Roman",
                SKFontStyle = new SKFontStyle(SKFontStyleWeight.ExtraBold, SKFontStyleWidth.Normal, SKFontStyleSlant.Italic)
            },

            // Use the Labeler property to give format to the axis values // mark
            // Now the Y axis we will display it as currency
            // LiveCharts provides some common formatters
            // in this case we are using the currency formatter.
            Labeler = Labelers.Currency, // mark

            Position = LiveChartsCore.Measure.AxisPosition.End,
            InLineNamePlacement = true,

            // you could also build your own currency formatter
            // for example:
            // Labeler = (value) => value.ToString("C")

            // But the one that LiveCharts provides creates shorter labels when
            // the amount is in millions or trillions
        }
    };

    public DrawMarginFrame DrawMarginFrame => new()
    {
        Stroke = new SolidColorPaint(new SKColor(180, 180, 180), 1)
    };
}
