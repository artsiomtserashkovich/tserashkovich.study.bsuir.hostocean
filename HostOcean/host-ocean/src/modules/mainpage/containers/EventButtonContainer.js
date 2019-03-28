import React from "react";
import { connect } from 'react-redux';
import { bindActionCreators } from "redux";

import * as queueActions from "../actions/queuesActions"
import EventButton from "../components/EventButton";

class EventButtonContainer extends React.Component {
    constructor(props) {
        super(props);
        this.state = {
            currentCount: Date.parse(props.registrationStartedAt) - new Date(),
            isRegistrationStarted: Date.parse(props.registrationStartedAt) <= new Date()
        }
    }

    componentDidMount() {
        var intervalId = setInterval(this.timer, 1000);
        this.setState({ intervalId: intervalId });
    }

    componentWillUnmount() {
        clearInterval(this.state.intervalId);
    }

    getDate(currentCount) {
        const options = {minimumIntegerDigits: 2, useGrouping:false};
       
        let date = currentCount;
        const hours = Math.floor(date / (60 * 60 * 1000)).toLocaleString('en-US', options);
        date %= (60 * 60 * 1000);

        const minutes = Math.floor(date / (60 * 1000)).toLocaleString('en-US', options);
        date %= (60 * 1000);

        const seconds = Math.floor(date / 1000).toLocaleString('en-US', options);

        return `${hours}:${minutes}:${seconds}`;
    }

    timer = () => {
        const isRegistrationStarted = Date.parse(this.props.registrationStartedAt) <= new Date();

        this.setState({ 
            currentCount: Date.parse(this.props.registrationStartedAt) - new Date(),
            isRegistrationStarted
        });

        if (isRegistrationStarted) {
            clearInterval(this.state.intervalId);
        }
    }

    onTakeQueue = () => {
        const { queue, user, takeQueueRequest } = this.props;

        takeQueueRequest({ queueId: queue.id, userId: user.id })
    }

    onLeaveQueue = () => {
        const { queue, user, leaveQueueRequest } = this.props;

        leaveQueueRequest({ queueId: queue.id, userId: user.id })
    }

    render() {
        const { queue, isAlreadyInQueue, registrationStartedAt } = this.props;
        const { currentCount, isRegistrationStarted } = this.state;

        const remains = this.getDate(currentCount);

        const props = {
            queue,
            isAlreadyInQueue,
            isRegistrationStarted,
            registrationStartedAt,
            remains,
            onTakeQueue: this.onTakeQueue,
            onLeaveQueue: this.onLeaveQueue
        }

        return <EventButton {...props} />;
    }
}

const mapStateToProps = (state, props) => {
    const queue = state.mainpage.queues[props.queueId];
    const user = state.user;
    const registrationStartedAt = state.mainpage.events[props.eventId].registrationStartedAt;
    const isAlreadyInQueue = queue && queue.userQueues ? queue.userQueues.some(u => u.user.id === user.id) : false;

    return ({
        queue,
        user,
        isAlreadyInQueue,
        registrationStartedAt
    });
}

const mapDispatchToProps = (dispatch) => {
    return ({
        ...bindActionCreators({ ...queueActions }, dispatch)
    });
}

export default connect(mapStateToProps, mapDispatchToProps)(EventButtonContainer);