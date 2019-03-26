import React from "react";
import { connect } from 'react-redux';
import { bindActionCreators } from "redux";

import Queue from "./../components/Queue"
import * as queueActions from "./../actions/queuesActions"

class LabworkContainer extends React.Component {
    onTakeQueue = () => {
        const { queue, user, takeQueueRequest } = this.props;

        takeQueueRequest({ queueId: queue.id, userId: user.id })
    }

    onLeaveQueue = () => {
        const { queue, user, leaveQueueRequest } = this.props;

        leaveQueueRequest({ queueId: queue.id, userId: user.id })
    }

    render() {
        const { queue, isAlreadyInQueue } = this.props;

        const props = {
            queue,
            isAlreadyInQueue,
            onTakeQueue: this.onTakeQueue,
            onLeaveQueue: this.onLeaveQueue
        }

        return <Queue {...props} />;
    }
}

const mapStateToProps = (state, props) => {
    const queue = state.mainpage.queues[props.queueId];
    const user = state.user;
    const isAlreadyInQueue = queue && queue.userQueues ? queue.userQueues.some(u => u.user.id === user.id) : false;

    return ({
        queue,
        user,
        isAlreadyInQueue
    });
}

const mapDispatchToProps = (dispatch, props) => {
    return ({
        ...bindActionCreators({ ...queueActions }, dispatch)
    });
}

export default connect(mapStateToProps, mapDispatchToProps)(LabworkContainer);