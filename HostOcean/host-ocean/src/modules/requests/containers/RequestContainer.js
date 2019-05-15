import React from "react";
import { connect } from "react-redux";
import { bindActionCreators } from "redux";

import Request from "../components/Request";

import * as actions from "../actions/index";
import { RequestState } from "../../shared/enums";

class RequestContainer extends React.Component {
    expireRequest = () => {
        const { request, updateRequestRequest } = this.props;

        updateRequestRequest({
            id: request.id,
            creatorUserId: request.creatorUserId,
            receiverUserId: request.receiverUserId,
            state: RequestState.Expired,
            queueId: request.queueId
        });
    };

    acceptRequest = () => {
        const { request, updateRequestRequest } = this.props;

        updateRequestRequest({
            id: request.id,
            creatorUserId: request.creatorUserId,
            receiverUserId: request.receiverUserId,
            state: RequestState.Accepted,
            queueId: request.queueId
        });
    };

    declineRequest = () => {
        const { request, updateRequestRequest } = this.props;

        updateRequestRequest({
            id: request.id,
            creatorUserId: request.creatorUserId,
            receiverUserId: request.receiverUserId,
            state: RequestState.Declined,
            queueId: request.queueId
        });
    };

    render() {
        const { request, isRequestOwner } = this.props;

        const props = {
            ...request,
            isRequestOwner,
            acceptRequest: this.acceptRequest,
            declineRequest: this.declineRequest,
            expireRequest: this.expireRequest
        };

        return <Request {...props} />;
    }
}

const mapStateToProps = (state, props) => {
    return {
        request: state.requests[props.requestId],
        isRequestOwner:
            state.requests[props.requestId] &&
            state.user.id === state.requests[props.requestId].creatorUserId
    };
};

const mapDispatchToProps = (dispatch, props) => {
    return {
        ...bindActionCreators({ ...actions }, dispatch)
    };
};

export default connect(
    mapStateToProps,
    mapDispatchToProps
)(RequestContainer);
