import React from "react";
import PropTypes from "prop-types";

import FormHelperText from "@material-ui/core/FormHelperText";

const ErrorLabel = ({ error, touched }) =>
  touched && error ? <FormHelperText error>{error}</FormHelperText> : "";

ErrorLabel.propTypes = {
  error: PropTypes.any,
  touched: PropTypes.bool.isRequired
};

export default ErrorLabel;