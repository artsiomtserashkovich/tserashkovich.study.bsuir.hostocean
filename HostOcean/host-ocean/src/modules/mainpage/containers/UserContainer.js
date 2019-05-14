import React from "react";
import { connect } from "react-redux";
import { bindActionCreators } from "redux";

import User from "../components/User";
import * as requestsActions from "../../requests/actions";
import { RequestState } from "../../shared/enums";

class UserContainer extends React.Component {
    createSwapRequest = userId => () => {
        const { queueId, createSwapRequestRequest } = this.props;

        createSwapRequestRequest({
            queueId,
            receiverUserId: userId
        });
    };

    declineSwapRequest = () => {
        const { request, updateRequestRequest, queueId } = this.props;

        updateRequestRequest({
            id: request.id,
            creatorUserId: request.creatorUserId,
            state: RequestState.Declined,
            queueId
        });
    };

    acceptSwapRequest = () => {
        const { request, updateRequestRequest, queueId } = this.props;

        updateRequestRequest({
            id: request.id,
            creatorUserId: request.creatorUserId,
            state: RequestState.Accepted,
            queueId
        });
    };

    render() {
        const {
            user,
            order,
            isUser,
            isLoading,
            isRequestAlreadySended,
            isPedingRequestFromUser,
            isUserInQueue
        } = this.props;

        const props = {
            user,
            order,
            isUser,
            isRequestLoading: isLoading,
            isUserInQueue,
            isRequestAlreadySended,
            isPedingRequestFromUser,
            createSwapRequest: this.createSwapRequest,
            acceptSwapRequest: this.acceptSwapRequest,
            declineSwapRequest: this.declineSwapRequest
        };

        return <User {...props} />;
    }
}

const mapStateToProps = (state, props) => {
    let isRequestAlreadySended = false;
    let isPedingRequestFromUser = false;
    let tempRequest;

    for (var key in state.requests) {
        const request = state.requests[key];
        if (
            request.queueId === props.queueId &&
            request.receiverUserId === props.user.id &&
            request.state === 0
        ) {
            isRequestAlreadySended = true;
        }

        if (
            request.queueId === props.queueId &&
            request.creatorUserId === props.user.id &&
            request.receiverUserId === state.user.id &&
            request.state === 0
        ) {
            isPedingRequestFromUser = true;
            tempRequest = request;
        }
    }

    let isUserInQueue = state.mainpage.queues[props.queueId].userQueues.some(
        uq => uq.userId === state.user.id
    );

    return {
        request: tempRequest,
        isUser: state.user.id === props.user.id,
        isUserInQueue,
        isRequestAlreadySended,
        isPedingRequestFromUser
    };
};

const mapDispatchToProps = (dispatch, props) => {
    return {
        ...bindActionCreators({ ...requestsActions }, dispatch)
    };
};

export default connect(
    mapStateToProps,
    mapDispatchToProps
)(UserContainer);
