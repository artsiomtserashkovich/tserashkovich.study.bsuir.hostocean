import React from "react";
import PropTypes from "prop-types";

import classNames from "classnames";
import InputLabel from "@material-ui/core/InputLabel";
import FormControl from "@material-ui/core/FormControl";

import ErrorLabel from "./../ErrorLabel";

const FormInputField = ({ classes, title, touched, error, children }) => (
  <FormControl className={classNames(classes.textField)}>
    <InputLabel>{title}</InputLabel>
    {children}
    <ErrorLabel error={error} touched={touched} />
  </FormControl>
);

FormInputField.propTypes = {
  classes: PropTypes.object.isRequired,
  children: PropTypes.any.isRequired,
  touched: PropTypes.any.isRequired,
  error: PropTypes.any,
  title: PropTypes.string.isRequired
};

export default FormInputField;