import * as React from "react";
import { bindActionCreators } from "redux";
import { connect } from "react-redux";

import * as eventsActions from "../../mainpage/actions/eventsActions"

import AccountSettings from "../components/AccountSettings";

class AccountSettingsContainer extends React.Component {
    componentDidMount() {
        const { getEventsRequest, groupId } = this.props;

        getEventsRequest({ groupId });
    }

    render() {
        return <AccountSettings />;
    }
}

const mapStateToProps = state => ({
    groupId: state.user.groupId
});

const mapDispatchToProps = dispatch => ({
    ...bindActionCreators(eventsActions, dispatch)
});

export default connect(
    mapStateToProps,
    mapDispatchToProps
)(AccountSettingsContainer);
