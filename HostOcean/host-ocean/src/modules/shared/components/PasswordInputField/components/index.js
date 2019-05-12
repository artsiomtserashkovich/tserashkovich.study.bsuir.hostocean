import React from "react";
import PropTypes from "prop-types";

import IconButton from "@material-ui/core/IconButton";
import Input from "@material-ui/core/Input";
import InputLabel from "@material-ui/core/InputLabel";
import InputAdornment from "@material-ui/core/InputAdornment";
import Visibility from "@material-ui/icons/Visibility";
import VisibilityOff from "@material-ui/icons/VisibilityOff";

import FormInputField from "../../InputField";

const PasswordInput = ({
  classes,
  input,
  title,
  meta: { touched, error },
  visibility,
  handleClickShowPassword,
  handleMouseDownPassword
}) => {
  return (
    <FormInputField title={title} classes={classes} error={error} touched={touched}>
      <InputLabel>{title}</InputLabel>
      <Input
        {...input}
        error={error && touched}
        required
        autoComplete="password"
        type={visibility ? "text" : "password"}
        endAdornment={
          <InputAdornment
            position="end"
            onClick={handleClickShowPassword}
            onMouseDown={handleMouseDownPassword}
          >
            <IconButton>
              {visibility ? <VisibilityOff /> : <Visibility />}
            </IconButton>
          </InputAdornment>
        }
      />
    </FormInputField>
  );
};

PasswordInput.propTypes = {
  classes: PropTypes.object.isRequired,
  title: PropTypes.string.isRequired,
  input: PropTypes.object.isRequired,
  meta: PropTypes.object.isRequired,
  showPassword: PropTypes.bool,
  handleClickShowPassword: PropTypes.func.isRequired,
  handleMouseDownPassword: PropTypes.func.isRequired
};

export default PasswordInput;