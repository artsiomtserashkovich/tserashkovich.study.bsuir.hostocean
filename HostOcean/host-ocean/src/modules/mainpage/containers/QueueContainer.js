import React from "react";
import { connect } from 'react-redux';

import Queue from "./../components/Queue"

class LabworkContainer extends React.Component {
    onTakeQueue = () => {
        const {queue} = this.props;
    }

    render() {
        const { queue } = this.props;

        return <Queue queue={queue} />;
    }
}

const mapStateToProps = (state, props) => {
    const queueId = state.mainpage.labworks[props.labworkId].queueId
    const queue = state.mainpage.queues[queueId];
    return ({
        queue
    });
}

const mapDispatchToProps = (dispatch, props) => {
    return ({});
}

export default connect(mapStateToProps, mapDispatchToProps)(LabworkContainer);