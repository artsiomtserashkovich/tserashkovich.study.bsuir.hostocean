import React from "react";
import PropTypes from "prop-types";

import classNames from "classnames";
import FormControl from "@material-ui/core/FormControl";

import ErrorLabel from "./../ErrorLabel";

const FormInputField = ({ classes, touched, error, children }) => (
  <FormControl className={classNames(classes.textField)}>
    {children}
    <ErrorLabel error={error} touched={touched} />
  </FormControl>
);

FormInputField.propTypes = {
  classes: PropTypes.object.isRequired,
  children: PropTypes.any.isRequired,
  touched: PropTypes.any.isRequired,
  error: PropTypes.any
};

export default FormInputField;