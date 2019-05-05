import React from "react";
import StatisticForm from "../components/StatisticsForm";
import StatisticChartList from "../components/StatisticChartList"
import { Grid } from "@material-ui/core";
import * as am4core from "@amcharts/amcharts4/core";
import am4themes_animated from "@amcharts/amcharts4/themes/animated";
import { bindActionCreators } from "redux";
import { connect } from "react-redux";
import * as statisticActions from "../actions/statisticActions";

am4core.useTheme(am4themes_animated);

class StatisticsContainer extends React.Component {
    validateStatisticForm = (values, {syncErrors}) => {
        const errors = { ...syncErrors };
        
        errors.endPeriod = undefined;
        errors.startPeriod = values.startPeriod > values.endPeriod 
            ? "Start Period have to be less then End Period" 
            : undefined;
        return errors;
    }

    getStatistic = (statisticPeriod) => {
        const { getStatisticRequest } = this.props;
        getStatisticRequest(statisticPeriod);
    }

    render() {
        const { statistic } = this.props;
        const statisticFormProps = {
            statistics: this.getStatistic,
            validate: this.validateStatisticForm,
        }

        return (
            <Grid container direction={"column"}>
                <Grid item lg={3} md={6} xs={12}>
                    <StatisticForm {...statisticFormProps} />
                </Grid>
                {!!statistic.isLoaded && <Grid item xs={12} lg={12} md={12}>
                    <StatisticChartList statistic={statistic}/>
                </Grid>}
            </Grid>
        );
    }
}

const mapStateToProps = (state) => ({
    statistic: state.statistic
});


const mapDispatchToProps = (dispatch) => ({
    ...bindActionCreators({...statisticActions }, dispatch)
});

export default connect(
    mapStateToProps,
    mapDispatchToProps
)(StatisticsContainer);