import * as React from "react";
import { connect } from "react-redux";
import { bindActionCreators } from "redux";

import MainPage from "./../components/MainPage/index";

import * as requestsActions from "../../requests/actions";

class MainPageContainer extends React.Component {
    componentDidMount() {
        const { getRequestsRequest } = this.props;

        getRequestsRequest();
    }

    render() {
        const props = {};
        return <MainPage {...props} />;
    }
}

const mapStateToProps = state => {
    return {
        events: state.mainpage.events,
        groupId: state.user.groupId
    };
};

const mapDispatchToProps = dispatch => {
    return { ...bindActionCreators({ ...requestsActions }, dispatch) };
};

export default connect(
    mapStateToProps,
    mapDispatchToProps
)(MainPageContainer);
