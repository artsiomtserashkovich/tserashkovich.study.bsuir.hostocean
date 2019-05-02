import PropTypes from 'prop-types';
import React from 'react';
import styles from "./styles";

const formName = "statistics";


function StatisticsFormContainer(props) {
    const { classes, handleSubmit } = props;
    return (
        <form onSubmit={handleSubmit}>
            <label htmlFor="startPeriod">Start Period:</label>
            <Field name="startPeriod" component="input" type="date" />
            <label htmlFor="endPeriod">End Period:</label>
            <Field name="endPeriod" component="input" type="date" />
        </form>
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
