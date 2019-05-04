import * as React from "react";
import PropTypes from 'prop-types';
import * as am4core from "@amcharts/amcharts4/core";
import * as am4charts from "@amcharts/amcharts4/charts";
import { withStyles } from "@material-ui/core";
import styles from "./styles";

class StatisticChart extends React.Component {
    componentDidMount() {
        this.chart = am4core.create(this.props.chartId, am4charts.XYChart);

        this.chart.data = this.props.data;
        this.createDateAxis();
        this.createValueAxis();
        this.chart.series.push(this.createLineSeries());
        this.chart.cursor = this.createCursor();
    }

    componentDidUpdate() {
        this.chart.data = this.props.date;
    }

    componentWillUnmount(){
        if (this.chart) {
            this.chart.dispose();
        }
    }

    render(){
        const { chartId } = this.props;
        return(
            <div id={chartId}></div>
        )
    }

    createLineSeries() {
        let series = new am4charts.LineSeries();

        series.bullets.push(this.createValueBullet())
        series.tooltipText = this.props.seriesTooltipTextPattern;
        series.dataFields.dateX = this.props.seriesDataField;
        series.dataFields.valueY = this.props.seriesValueField;
        series.tensionX = 0.8;
        series.strokeWidth = 2;
        series.tooltip.getFillFromObject = false;
        series.tooltip.background.fill = this.props.colorSchema;
        series.stroke = this.props.colorSchema;

        return series;
    }

    createValueBullet() {
        let valueBullet = new am4charts.CircleBullet();

        valueBullet.circle.opacity = 0;
        valueBullet.circle.fill = this.props.colorSchema;
        valueBullet.circle.propertyFields.opacity = this.props.seriesValueField;
        valueBullet.circle.radius = 3;

        return valueBullet;
    }

    createCursor() {
        let cursor = new am4charts.XYCursor();

        cursor.lineY.disabled = true;
        cursor.behavior = "zoomX";

        return cursor;
    }

    createValueAxis(chart) {
        let axis = this.chart.yAxes.push(new am4charts.ValueAxis());

        axis.min = 0;
        axis.renderer.grid.template.disabled = true;
        axis.renderer.baseGrid.disabled = true;
        axis.renderer.labels.template.disabled = true;
        axis.cursorTooltipEnabled = false;

        return axis;
    }

    createDateAxis() {
        let axis = this.chart.xAxes.push(new am4charts.DateAxis());

        axis.renderer.grid.template.disabled = true;
        axis.startLocation = 0.7;
        axis.endLocation = 0.7;
        axis.cursorTooltipEnabled = false;

        return axis;
    }
}

StatisticChart.propTypes = {
    chartId: PropTypes.string.isRequired,
    data: PropTypes.array.isRequired,
    colorSchema: PropTypes.string.isRequired,
    seriesDataField: PropTypes.string.isRequired,
    seriesValueField: PropTypes.string.isRequired,
    seriesTooltipTextPattern: PropTypes.string.isRequired,
    classes: PropTypes.object.isRequired,
}

export default withStyles(styles)(StatisticChart);
