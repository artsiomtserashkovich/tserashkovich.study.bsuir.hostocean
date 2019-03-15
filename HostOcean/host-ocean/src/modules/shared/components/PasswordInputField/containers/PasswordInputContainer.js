import React from "react";
import PropTypes from "prop-types";
import PasswordInput from "../components";

class PasswordInputContainer extends React.Component {
  constructor(props) {
    super(props);
    this.state = {
      visibility: false
    };
    this.handleClickShowPassword = this.handleClickShowPassword.bind(this);
    this.handleMouseDownPassword = this.handleMouseDownPassword.bind(this);
  }

  handleMouseDownPassword(event) {
    event.preventDefault();
  }

  handleClickShowPassword() {
    const { visibility } = this.state;
    this.setState({ visibility: !visibility });
  }

  render() {
    const {title} = this.props;
    const { visibility } = this.state;

    const props = {
      handleClickShowPassword: this.handleClickShowPassword,
      handleMouseDownPassword: this.handleMouseDownPassword,
      visibility
    };

    return <PasswordInput title={title} {...props} {...this.props} />;
  }
}

PasswordInputContainer.propTypes = {
    title: PropTypes.string.isRequired
};

export default PasswordInputContainer;