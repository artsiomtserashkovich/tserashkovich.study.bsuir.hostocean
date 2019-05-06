import * as React from "react";
import { bindActionCreators } from "redux";
import { connect } from "react-redux";

import PropTypes from "prop-types";

import UserCard from "../components/UserCard";

import * as rawActions from "../actions/index";

class UserEventsContainer extends React.Component {
    render() {
        const { user, isEditing } = this.props;

        const props = {
            user,
            isEditing,
            editInfo: this.editInfo,
            saveInfo: this.saveInfo
        };

        return "test"
    }
}

UserEventsContainer.propTypes = {
    user: PropTypes.object.isRequired,
    isEditing: PropTypes.bool.isRequired
};

const mapStateToProps = state => ({
    user: state.user,
});

const mapDispatchToProps = dispatch => ({
    ...bindActionCreators(rawActions, dispatch)
});

export default connect(
    mapStateToProps,
    mapDispatchToProps
)(UserEventsContainer);
