am4core.useTheme(am4themes_animated);

  var container = am4core.create("chartdiv", am4core.Container);
  container.layout = "grid";
  container.fixedWidthGrid = false;
  container.width = am4core.percent(100);
  container.height = am4core.percent(100);

  var colors = new am4core.ColorSet();

  function createColumn(title, data, color) {

    var chart = container.createChild(am4charts.XYChart);
    chart.width = am4core.percent(45);
    chart.height = 70;

    chart.data = data;

    chart.titles.template.fontSize = 10;
    chart.titles.template.textAlign = "left";
    chart.titles.template.isMeasured = false;
    chart.titles.create().text = title;

    chart.padding(20, 5, 2, 5);

    var dateAxis = chart.xAxes.push(new am4charts.DateAxis());

    dateAxis.renderer.grid.template.disabled = true;
    dateAxis.renderer.labels.template.disabled = true;
    dateAxis.cursorTooltipEnabled = false;

    var valueAxis = chart.yAxes.push(new am4charts.ValueAxis());
    
    valueAxis.min = 0;

    valueAxis.renderer.grid.template.disabled = true;
    valueAxis.renderer.baseGrid.disabled = true;
    valueAxis.renderer.labels.template.disabled = true;
    valueAxis.cursorTooltipEnabled = false;

    chart.cursor = new am4charts.XYCursor();
    chart.cursor.lineY.disabled = true;

    var series = chart.series.push(new am4charts.ColumnSeries());
    series.tooltipText = "{date}: [bold]{value}";
    series.dataFields.dateX = "date";
    series.dataFields.valueY = "value";
    series.strokeWidth = 0;
    series.fillOpacity = 0.5;
    series.columns.template.propertyFields.fillOpacity = "opacity";
    series.columns.template.fill = color;

    return chart;
  }

  createColumn("AAPL (Turnover)", [
    { "date": new Date(2018, 0, 1, 8, 0, 0), "value": 22 }, 
    { "date": new Date(2018, 0, 1, 9, 0, 0), "value": 25 }, 
    { "date": new Date(2018, 0, 1, 10, 0, 0), "value": 40 }, 
    { "date": new Date(2018, 0, 1, 11, 0, 0), "value": 35 }, 
    { "date": new Date(2018, 0, 1, 12, 0, 0), "value": 29 }, 
    { "date": new Date(2018, 0, 1, 13, 0, 0), "value": 1 }, 
    { "date": new Date(2018, 0, 1, 14, 0, 0), "value": 15 }, 
    { "date": new Date(2018, 0, 1, 15, 0, 0), "value": 29 }, 
    { "date": new Date(2018, 0, 1, 16, 0, 0), "value": 33, "opacity": 1 }
  ], colors.getIndex(0)); 

  createColumn("MSFT (Turnover)", [
    { "date": new Date(2018, 0, 1, 8, 0, 0), "value": 57 }, 
    { "date": new Date(2018, 0, 1, 9, 0, 0), "value": 27 }, 
    { "date": new Date(2018, 0, 1, 10, 0, 0), "value": 24 }, 
    { "date": new Date(2018, 0, 1, 11, 0, 0), "value": 59 }, 
    { "date": new Date(2018, 0, 1, 12, 0, 0), "value": 33 }, 
    { "date": new Date(2018, 0, 1, 13, 0, 0), "value": 46 }, 
    { "date": new Date(2018, 0, 1, 14, 0, 0), "value": 20 }, 
    { "date": new Date(2018, 0, 1, 15, 0, 0), "value": 42 }, 
    { "date": new Date(2018, 0, 1, 16, 0, 0), "value": 59, "opacity": 1 }
   ], colors.getIndex(1));

  createColumn("AMZN (Turnover)", [
    { "date": new Date(2018, 0, 1, 8, 0, 0), "value": 50 }, 
    { "date": new Date(2018, 0, 1, 9, 0, 0), "value": 51 }, 
    { "date": new Date(2018, 0, 1, 10, 0, 0), "value": 62 }, 
    { "date": new Date(2018, 0, 1, 11, 0, 0), "value": 60 }, 
    { "date": new Date(2018, 0, 1, 12, 0, 0), "value": 25 }, 
    { "date": new Date(2018, 0, 1, 13, 0, 0), "value": 20 }, 
    { "date": new Date(2018, 0, 1, 14, 0, 0), "value": 70 }, 
    { "date": new Date(2018, 0, 1, 15, 0, 0), "value": 42 }, 
    { "date": new Date(2018, 0, 1, 16, 0, 0), "value": 33, "opacity": 1 }
   ], colors.getIndex(2));

  createColumn("FB (Turnover)", [
    { "date": new Date(2018, 0, 1, 8, 0, 0), "value": 20 }, 
    { "date": new Date(2018, 0, 1, 9, 0, 0), "value": 20 }, 
    { "date": new Date(2018, 0, 1, 10, 0, 0), "value": 25 }, 
    { "date": new Date(2018, 0, 1, 11, 0, 0), "value": 26 }, 
    { "date": new Date(2018, 0, 1, 12, 0, 0), "value": 29 }, 
    { "date": new Date(2018, 0, 1, 13, 0, 0), "value": 27 }, 
    { "date": new Date(2018, 0, 1, 14, 0, 0), "value": 25 }, 
    { "date": new Date(2018, 0, 1, 15, 0, 0), "value": 32 }, 
    { "date": new Date(2018, 0, 1, 16, 0, 0), "value": 30, "opacity": 1 }
   ], colors.getIndex(3));