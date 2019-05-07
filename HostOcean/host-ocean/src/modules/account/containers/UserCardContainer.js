import * as React from "react";
import { bindActionCreators } from "redux";
import { connect } from "react-redux";

import PropTypes from "prop-types";

import UserCard from "../components/UserCard";

import * as rawActions from "./../actions/index";

class UserCardContainer extends React.Component {
    editInfo = () => {
        const { editUserInfo } = this.props;
        editUserInfo();
    };

    saveInfo = values => {
        const { saveUserInfo, updateUserRequest } = this.props;
        saveUserInfo();
        updateUserRequest(values);
    };

    render() {
        const { user, isEditing } = this.props;

        const props = {
            user,
            isEditing,
            editInfo: this.editInfo,
            saveInfo: this.saveInfo
        };

        return <UserCard {...props} />;
    }
}

UserCardContainer.propTypes = {
    user: PropTypes.object.isRequired,
    isEditing: PropTypes.bool.isRequired
};

const mapStateToProps = state => ({
    user: state.user,
    isEditing: state.form.userInfo.isEditing || false
});

const mapDispatchToProps = dispatch => ({
    ...bindActionCreators(rawActions, dispatch)
});

export default connect(
    mapStateToProps,
    mapDispatchToProps
)(UserCardContainer);
