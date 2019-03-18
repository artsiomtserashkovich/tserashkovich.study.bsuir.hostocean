import * as React from 'react';
import { connect } from "react-redux";
import { bindActionCreators } from "redux";
import PropTypes from 'prop-types';

import LoginForm from "../components/LoginForm";
import * as actions from "./../actions/index";
import * as sessionActions from "./../../../state/actions/sessionActions";

class RegisterFormContainer extends React.Component {
    componentDidMount() {
        const {removeToken, removeUser} = this.props;
        
        removeToken();
        removeUser();
    }

    login = ({ username, password }) => {
        const { loginRequest } = this.props;

        loginRequest({ username, password })
    };

    validateValues = (values, { syncErrors }) => {
        const errors = { ...syncErrors };
        errors.username = undefined;
        errors.password = undefined;

        return errors;
    };

    render() {
        const props = {
            login: this.login,
            validate: this.validateValues
        };

        return (
            <LoginForm {...props} />
        );
    }
}

RegisterFormContainer.propTypes = {
    loginRequest: PropTypes.func.isRequired
}

const mapStateToProps = (state) => ({
});

const mapDispatchToProps = (dispatch) => ({
    ...bindActionCreators({ ...actions, ...sessionActions }, dispatch),
});

export default connect(
    mapStateToProps,
    mapDispatchToProps
)(RegisterFormContainer);
