import * as React from "react";
import { bindActionCreators } from "redux";
import { connect } from "react-redux";
import * as _ from "lodash";

import PropTypes from "prop-types";

import * as rawActions from "../actions/index";
import UserEvents from "../components/UserEvents";

class UserEventsContainer extends React.Component {
    render() {
        const { events } = this.props;
        const props = { events };

        return <UserEvents {...props} />;
    }
}

UserEventsContainer.propTypes = {
    events: PropTypes.array.isRequired
};

const mapStateToProps = state => ({
    events: _.filter(
        state.mainpage.events,
        e =>
            e &&
            e.queue &&
            e.queue.userQueues.some(uq => uq.user.id === state.user.id)
    )
});

const mapDispatchToProps = dispatch => ({
    ...bindActionCreators(rawActions, dispatch)
});

export default connect(
    mapStateToProps,
    mapDispatchToProps
)(UserEventsContainer);
