import React from "react";
import { connect } from "react-redux";

import Queue from "./../components/Queue";

class QueueContainer extends React.Component {
    render() {
        const { queue } = this.props;

        const props = {
            queue
        };

        return <Queue {...props} />;
    }
}

const mapStateToProps = (state, props) => {
    const queue = state.mainpage.queues[props.queueId];

    return {
        queue
    };
};

const mapDispatchToProps = dispatch => {
    return {};
};

export default connect(
    mapStateToProps,
    mapDispatchToProps
)(QueueContainer);
