import * as React from 'react';
import { connect } from "react-redux";
import { bindActionCreators } from "redux";
import PropTypes from 'prop-types';

import LoginForm from "../components/LoginForm";
import * as actions from "./../actions/index";
import * as sessionActions from "./../../../state/actions/sessionActions";
import * as signalrActions from "./../../../state/actions/signalrActions";

class RegisterFormContainer extends React.Component {
    componentDidMount() {
        const {removeToken, removeUser, terminateConnection} = this.props;
        
        removeToken();
        removeUser();
        terminateConnection();
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
    ...bindActionCreators({ ...actions, ...sessionActions, ...signalrActions }, dispatch),
});

export default connect(
    mapStateToProps,
    mapDispatchToProps
)(RegisterFormContainer);
