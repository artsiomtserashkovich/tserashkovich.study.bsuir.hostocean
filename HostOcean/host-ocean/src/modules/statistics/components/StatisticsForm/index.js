import React from 'react';
import styles from "./styles";
import { Paper, Button, withStyles, Grid } from "@material-ui/core";
import InlineDatePicker from "../../../shared/components/InlineDatePickerInputField";
import { Field, reduxForm } from "redux-form";

const formName = "statistics";

function StatisticsFormContainer(props) {
    const { classes, handleSubmit, statistics } = props;
    return (
        <form onSubmit={handleSubmit(statistics)}>
            <Paper className={classes.paper}>
                <Grid
                    container
                    direction="row"
                    className={classes.gridContainer}
                >
                    <Grid item lg={6} md={6} xs={12}>
                        <Field
                            name={"startPeriod"}
                            label='Start Period'
                            component={InlineDatePicker}
                        />
                    </Grid>
                    <Grid item lg={6} md={6} xs={12}>
                        <Field
                            name={"endPeriod"}
                            label='End Period:'
                            component={InlineDatePicker}
                        />
                    </Grid>
                    <Grid item lg={6} md={6} xs={12}>
                        <Button variant="outlined" className={classes.button} type="submit">
                            Get Statistic
                        </Button>
                    </Grid>
                </Grid>
            </Paper>
        </form>
    );
}

export default reduxForm({
    form: formName,
    touchOnChange: true,
    touchOnBlur: true,
    initialValues: {
       startPeriod: new Date(),
       endPeriod: new Date(),
    }
})(withStyles(styles)(StatisticsFormContainer));
