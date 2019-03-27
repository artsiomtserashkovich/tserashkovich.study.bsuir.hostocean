import * as React from 'react';
import { connect } from "react-redux";
import { bindActionCreators } from "redux";
import { change, updateSyncErrors } from "redux-form";
import PropTypes from 'prop-types';

import RegisterForm from "../components/RegisterForm";

import * as actions from "../actions/index";
import * as groupActions from "../../groups/actions/index";
import * as sessionActions from "./../../../state/actions/sessionActions";
import * as signalrActions from "./../../../state/actions/signalrActions";

class RegisterFormContainer extends React.Component {
    componentDidMount = () => {
        const { getGroupsRequest, removeToken, removeUser, resetState, terminateConnection} = this.props;
        
        removeToken();
        removeUser();
        terminateConnection();
        resetState();
        getGroupsRequest();
    };

    register = ({ username, email, password, confirm, group }) => {
        const { registerRequest, groupsList } = this.props;
        const userGroup = groupsList.find(g => g.name === group);

        if (userGroup) {
            registerRequest({ username, email, password, confirm, groupId: userGroup.id })
        } else {
            const { updateSyncErrors } = this.props;
            updateSyncErrors('register', {
                "group": "Please, choose group from list"
            });
        }
    };

    validateValues = (values, { syncErrors }) => {
        const errors = { ...syncErrors };
        errors.username = undefined;
        errors.group = undefined;
        errors.password = undefined;
        errors.confirm = values.password === values.confirm ? undefined : "Passwords doesn't match"
        errors.email = undefined;
        return errors;
    };

    render() {
        const { groupsList } = this.props;

        const props = {
            register: this.register,
            validate: this.validateValues,
            groupsList
        };

        return (
            <RegisterForm {...props} />
        );
    }
}

RegisterFormContainer.propTypes = {
    registerRequest: PropTypes.func.isRequired,
    getGroupsRequest: PropTypes.func.isRequired,
    groupsList: PropTypes.array.isRequired
}

const mapStateToProps = (state) => ({
    groupsList: state.groups
});

const mapDispatchToProps = (dispatch) => ({
    change: bindActionCreators(change, dispatch),
    updateSyncErrors: bindActionCreators(updateSyncErrors, dispatch),
    ...bindActionCreators({ ...actions, ...groupActions, ...sessionActions, ...signalrActions }, dispatch)
});

export default connect(
    mapStateToProps,
    mapDispatchToProps
)(RegisterFormContainer);
