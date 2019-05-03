import React from 'react';
import styles from "./styles";
import { Paper, withStyles } from "@material-ui/core";
import * as am4core from "@amcharts/amcharts4/core";
import * as am4charts from "@amcharts/amcharts4/charts";

const chartId = "statisticdiv"

class StatisticChart extends React.Component {
    componentDidMount() {
        let chart = am4core.create(chartId, am4core.Container);
    }
    render() {
        const { classes } = this.props;
        return(
            <Paper className={classes.paper}>
                <div id={chartId} style={classes.chartContainetDiv}></div>
            </Paper>
        );
    }
}

export default withStyles(styles)(StatisticChart);

// am4core.ready(function() {

//     // Themes begin
//     am4core.useTheme(am4themes_frozen);
//     am4core.useTheme(am4themes_animated);
//     // Themes end
    
//       // Create chart instance
//       var container = am4core.create("chartdiv", am4core.Container);
//       container.layout = "grid";
//       container.fixedWidthGrid = false;
//       container.width = am4core.percent(100);
//       container.height = am4core.percent(100);
    
//       // Color set
//       var colors = new am4core.ColorSet();
    
//       // Functions that create various sparklines
//       function createLine(title, data, color) {
    
//         var chart = container.createChild(am4charts.XYChart);
//         chart.width = am4core.percent(45);
//         chart.height = 70;
    
//         chart.data = data;
    
//         chart.titles.template.fontSize = 10;
//         chart.titles.template.textAlign = "left";
//         chart.titles.template.isMeasured = false;
//         chart.titles.create().text = title;
    
//         chart.padding(20, 5, 2, 5);
    
//         var dateAxis = chart.xAxes.push(new am4charts.DateAxis());
//         dateAxis.renderer.grid.template.disabled = true;
//         dateAxis.renderer.labels.template.disabled = true;
//         dateAxis.startLocation = 0.5;
//         dateAxis.endLocation = 0.7;
//         dateAxis.cursorTooltipEnabled = false;
    
//         var valueAxis = chart.yAxes.push(new am4charts.ValueAxis());
//         valueAxis.min = 0;
//         valueAxis.renderer.grid.template.disabled = true;
//         valueAxis.renderer.baseGrid.disabled = true;
//         valueAxis.renderer.labels.template.disabled = true;
//         valueAxis.cursorTooltipEnabled = false;
    
//         chart.cursor = new am4charts.XYCursor();
//         chart.cursor.lineY.disabled = true;
//         chart.cursor.behavior = "none";
    
//         var series = chart.series.push(new am4charts.LineSeries());
//         series.tooltipText = "{date}: [bold]{value}";
//         series.dataFields.dateX = "date";
//         series.dataFields.valueY = "value";
//         series.tensionX = 0.8;
//         series.strokeWidth = 2;
//         series.stroke = color;
    
//         // render data points as bullets
//         var bullet = series.bullets.push(new am4charts.CircleBullet());
//         bullet.circle.opacity = 0;
//         bullet.circle.fill = color;
//         bullet.circle.propertyFields.opacity = "opacity";
//         bullet.circle.radius = 3;
    
//         return chart;
//       }
    
//       function createColumn(title, data, color) {
    
//         var chart = container.createChild(am4charts.XYChart);
//         chart.width = am4core.percent(45);
//         chart.height = 70;
    
//         chart.data = data;
    
//         chart.titles.template.fontSize = 10;
//         chart.titles.template.textAlign = "left";
//         chart.titles.template.isMeasured = false;
//         chart.titles.create().text = title;
    
//         chart.padding(20, 5, 2, 5);
    
//         var dateAxis = chart.xAxes.push(new am4charts.DateAxis());
//         dateAxis.renderer.grid.template.disabled = true;
//         dateAxis.renderer.labels.template.disabled = true;
//         dateAxis.cursorTooltipEnabled = false;
    
//         var valueAxis = chart.yAxes.push(new am4charts.ValueAxis());
//         valueAxis.min = 0;
//         valueAxis.renderer.grid.template.disabled = true;
//         valueAxis.renderer.baseGrid.disabled = true;
//         valueAxis.renderer.labels.template.disabled = true;
//         valueAxis.cursorTooltipEnabled = false;
    
//         chart.cursor = new am4charts.XYCursor();
//         chart.cursor.lineY.disabled = true;
    
//         var series = chart.series.push(new am4charts.ColumnSeries());
//         series.tooltipText = "{date}: [bold]{value}";
//         series.dataFields.dateX = "date";
//         series.dataFields.valueY = "value";
//         series.strokeWidth = 0;
//         series.fillOpacity = 0.5;
//         series.columns.template.propertyFields.fillOpacity = "opacity";
//         series.columns.template.fill = color;
    
//         return chart;
//       }
    
//       function createPie(data, color) {
    
//         var chart = container.createChild(am4charts.PieChart);
//         chart.width = am4core.percent(10);
//         chart.height = 70;
//         chart.padding(20, 0, 2, 0);
    
//         chart.data = data;
    
//         // Add and configure Series
//         var pieSeries = chart.series.push(new am4charts.PieSeries());
//         pieSeries.dataFields.value = "value";
//         pieSeries.dataFields.category = "category";
//         pieSeries.labels.template.disabled = true;
//         pieSeries.ticks.template.disabled = true;
//         pieSeries.slices.template.fill = color;
//         pieSeries.slices.template.adapter.add("fill", function(fill, target) {
//           return fill.lighten(0.1 * target.dataItem.index);
//         });
//         pieSeries.slices.template.stroke = am4core.color("#fff");
    
//         // chart.chartContainer.minHeight = 40;
//         // chart.chartContainer.minWidth = 40;
    
//         return chart;
//       }   
    
   
//       createColumn("AAPL (Turnover)", [
//         { "date": new Date(2018, 0, 1, 8, 0, 0), "value": 22 }, 
//         { "date": new Date(2018, 0, 1, 9, 0, 0), "value": 25 }, 
//         { "date": new Date(2018, 0, 1, 10, 0, 0), "value": 40 }, 
//         { "date": new Date(2018, 0, 1, 11, 0, 0), "value": 35 }, 
//         { "date": new Date(2018, 0, 1, 12, 0, 0), "value": 29 }, 
//         { "date": new Date(2018, 0, 1, 13, 0, 0), "value": 1 }, 
//         { "date": new Date(2018, 0, 1, 14, 0, 0), "value": 15 }, 
//         { "date": new Date(2018, 0, 1, 15, 0, 0), "value": 29 }, 
//         { "date": new Date(2018, 0, 1, 16, 0, 0), "value": 33, "opacity": 1 }
//       ], colors.getIndex(0));

//       createColumn("MSFT (Turnover)", [
//         { "date": new Date(2018, 0, 1, 8, 0, 0), "value": 57 }, 
//         { "date": new Date(2018, 0, 1, 9, 0, 0), "value": 27 }, 
//         { "date": new Date(2018, 0, 1, 10, 0, 0), "value": 24 }, 
//         { "date": new Date(2018, 0, 1, 11, 0, 0), "value": 59 }, 
//         { "date": new Date(2018, 0, 1, 12, 0, 0), "value": 33 }, 
//         { "date": new Date(2018, 0, 1, 13, 0, 0), "value": 46 }, 
//         { "date": new Date(2018, 0, 1, 14, 0, 0), "value": 20 }, 
//         { "date": new Date(2018, 0, 1, 15, 0, 0), "value": 42 }, 
//         { "date": new Date(2018, 0, 1, 16, 0, 0), "value": 59, "opacity": 1 }
//        ], colors.getIndex(1));
   
//       createColumn("AMZN (Turnover)", [
//         { "date": new Date(2018, 0, 1, 8, 0, 0), "value": 50 }, 
//         { "date": new Date(2018, 0, 1, 9, 0, 0), "value": 51 }, 
//         { "date": new Date(2018, 0, 1, 10, 0, 0), "value": 62 }, 
//         { "date": new Date(2018, 0, 1, 11, 0, 0), "value": 60 }, 
//         { "date": new Date(2018, 0, 1, 12, 0, 0), "value": 25 }, 
//         { "date": new Date(2018, 0, 1, 13, 0, 0), "value": 20 }, 
//         { "date": new Date(2018, 0, 1, 14, 0, 0), "value": 70 }, 
//         { "date": new Date(2018, 0, 1, 15, 0, 0), "value": 42 }, 
//         { "date": new Date(2018, 0, 1, 16, 0, 0), "value": 33, "opacity": 1 }
//        ], colors.getIndex(2));
    
//       // FB   
//       createColumn("FB (Turnover)", [
//         { "date": new Date(2018, 0, 1, 8, 0, 0), "value": 20 }, 
//         { "date": new Date(2018, 0, 1, 9, 0, 0), "value": 20 }, 
//         { "date": new Date(2018, 0, 1, 10, 0, 0), "value": 25 }, 
//         { "date": new Date(2018, 0, 1, 11, 0, 0), "value": 26 }, 
//         { "date": new Date(2018, 0, 1, 12, 0, 0), "value": 29 }, 
//         { "date": new Date(2018, 0, 1, 13, 0, 0), "value": 27 }, 
//         { "date": new Date(2018, 0, 1, 14, 0, 0), "value": 25 }, 
//         { "date": new Date(2018, 0, 1, 15, 0, 0), "value": 32 }, 
//         { "date": new Date(2018, 0, 1, 16, 0, 0), "value": 30, "opacity": 1 }
//        ], colors.getIndex(3));
    
//     }); 