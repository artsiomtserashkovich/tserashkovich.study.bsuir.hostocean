import React from "react";
import PropTypes from "prop-types";
import { InlineDatePicker } from "material-ui-pickers";
import moment from "moment";

const InlineDatePickerInputField = ({
    input,
    label,
    dateFormatter,
    dateParser,
    meta: { touched, invalid, error },
    ...rest,
}) =>(
    <InlineDatePicker
        error={touched && invalid}
        helperText={touched && error}
        label={label}
        onChange={val => 
            input.onChange(dateParser(val))
        }
        value={dateFormatter(input.value)}
        {...rest}
    />
)

InlineDatePickerInputField.propTypes = {
    dateFormatter: PropTypes.func,
    dateParser: PropTypes.func, 
    input: PropTypes.object.isRequired,
    label: PropTypes.string.isRequired,
    meta: PropTypes.object.isRequired,
};

InlineDatePickerInputField.defaultProps = {
    dateFormatter: date => moment(date),
    dateParser: date => moment(date).toDate(),
}
  
export default InlineDatePickerInputField;