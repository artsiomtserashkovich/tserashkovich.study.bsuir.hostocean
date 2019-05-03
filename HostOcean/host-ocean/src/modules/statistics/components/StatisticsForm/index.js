import PropTypes from 'prop-types';
import React from 'react';
import styles from "./styles";
import { Field, reduxForm } from "redux-form";
import { Paper, Button, withStyles } from "@material-ui/core";

const formName = "statistics";


function StatisticsFormContainer(props) {
    const { classes, handleSubmit } = props;
    return (
        <div className={classes.formsLayout}>
            <Paper className={classes.paper}>
                <form className={classes.form} onSubmit={handleSubmit}>
                    <Field
                        name="startPeriod"
                        title="Start Period"
                        type="date"
                        classes={classes}
                    />
                    <Field
                        name="endPeriod"
                        title="End Period"
                        type="date"
                        classes={classes}
                    />
                    <Button
                        type="submit"
                        color="primary"
                        variant="contained"
                        className={classes.submitButton}
                    >
                        Login
                    </Button>
                </form>
            </Paper>
        </div>
    );
}

StatisticsFormContainer.propTypes = {
    classes: PropTypes.object.isRequired,
}

export default reduxForm({
    form: formName,
    touchOnChange: false,
    touchOnBlur: true,
    initialValues: {
        startPeriod: new Date(),
        endPeriod: new Date(),
    }
})(withStyles(styles)(StatisticsFormContainer));
