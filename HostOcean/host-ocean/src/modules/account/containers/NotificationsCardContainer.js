import * as React from "react";
import { connect } from "react-redux";

import NotificationsCard from "../components/NotificationsCard";

class NotificationsCardContainer extends React.Component {
    render() {
        const props = {};

        return <NotificationsCard {...props} />;
    }
}

NotificationsCardContainer.propTypes = {};

const mapStateToProps = state => ({});

const mapDispatchToProps = dispatch => ({});

export default connect(
    mapStateToProps,
    mapDispatchToProps
)(NotificationsCardContainer);
