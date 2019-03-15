import React from "react";
import PropTypes from "prop-types";

import Input from "@material-ui/core/Input";

import FormInputField from "./InputField";

const DefaultInput = ({
  classes,
  input,
  title,
  type="text",
  meta: { touched, error },
  ...rest
}) => {
  return (
    <FormInputField
      classes={classes}
      title={title}
      touched={touched}
      error={error}
    >
      <Input {...rest} {...input} error={error && touched} type={type} required />
    </FormInputField>
  );
}

DefaultInput.propTypes = {
  classes: PropTypes.object.isRequired,
  input: PropTypes.object.isRequired,
  meta: PropTypes.object.isRequired
};

export default DefaultInput;