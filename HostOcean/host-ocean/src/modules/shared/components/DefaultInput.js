import React from "react";
import PropTypes from "prop-types";

import {TextField} from "@material-ui/core";

import FormInputField from "./InputField";

const DefaultInput = ({
  classes,
  input,
  title,
  type="text",
  meta: { touched, error },
  required = true,
  ...rest
}) => {
  return (
    <FormInputField
      classes={classes}
      title={title}
      touched={touched}
      error={error}
    >
      <TextField {...rest} {...input} label={title} error={error && touched} type={type} required={required} />
    </FormInputField>
  );
}

DefaultInput.propTypes = {
  classes: PropTypes.object.isRequired,
  input: PropTypes.object.isRequired,
  meta: PropTypes.object.isRequired
};

export default DefaultInput;