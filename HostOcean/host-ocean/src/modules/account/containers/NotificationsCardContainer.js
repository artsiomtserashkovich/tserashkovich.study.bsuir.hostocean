import * as React from "react";
import { bindActionCreators } from "redux";
import { connect } from "react-redux";

import PropTypes from "prop-types";

import NotificationsCard from "../components/NotificationsCard";

import * as rawActions from "./../actions/index";

class NotificationsCardContainer extends React.Component {
    changePassword = () => {
        console.log("change password")
    };

    render() {
        const props = {
            changePassword: this.changePassword
        };

        return <NotificationsCard {...props} />;
    }
}

NotificationsCardContainer.propTypes = {
};

const mapStateToProps = state => ({
});

const mapDispatchToProps = dispatch => ({
    ...bindActionCreators(rawActions, dispatch)
});

export default connect(
    mapStateToProps,
    mapDispatchToProps
)(NotificationsCardContainer);
