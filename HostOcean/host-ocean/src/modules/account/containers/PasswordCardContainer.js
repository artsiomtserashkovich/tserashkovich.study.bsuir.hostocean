import * as React from "react";
import { bindActionCreators } from "redux";
import { connect } from "react-redux";

import PropTypes from "prop-types";

import PasswordCard from "../components/PasswordCard";

import * as rawActions from "./../actions/index";

class PasswordCardContainer extends React.Component {
    changePassword = (values) => {
        const { changePasswordRequest } = this.props
        changePasswordRequest(values)
    };

    render() {
        const props = {
            changePassword: this.changePassword
        };

        return <PasswordCard {...props} />;
    }
}

PasswordCardContainer.propTypes = {
    changePasswordRequest: PropTypes.func.isRequired
};

const mapStateToProps = state => ({
});

const mapDispatchToProps = dispatch => ({
    ...bindActionCreators(rawActions, dispatch)
});

export default connect(
    mapStateToProps,
    mapDispatchToProps
)(PasswordCardContainer);
