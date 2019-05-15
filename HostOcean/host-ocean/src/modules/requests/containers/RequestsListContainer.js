import React from "react";
import { bindActionCreators } from "redux";
import { connect } from "react-redux";
import * as _ from "lodash";

import RequestsList from "../components/RequestsList/index";

import * as actions from "../actions/index";

class RequestsListContainer extends React.Component {
    componentDidMount() {
        const { getRequestsRequest, requests } = this.props;
        if (Object.keys(requests === 0)) {
            getRequestsRequest();
        }
    }

    render() {
        let { requests } = this.props;

        const sortedRequests = _.sortBy(requests, [
            r => new Date(r.createdOn)
        ]).reverse();

        const props = {
            requests: sortedRequests
        };

        return <RequestsList {...props} />;
    }
}

const mapStateToProps = state => {
    return {
        requests: state.requests
    };
};

const mapDispatchToProps = dispatch => {
    return { ...bindActionCreators({ ...actions }, dispatch) };
};

export default connect(
    mapStateToProps,
    mapDispatchToProps
)(RequestsListContainer);
