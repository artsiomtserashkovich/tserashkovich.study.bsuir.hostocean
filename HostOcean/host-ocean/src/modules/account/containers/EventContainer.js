import * as React from "react";
import { connect } from "react-redux";

import Event from "../components/Event";

class EventContainer extends React.Component {
    render() {
        const { event, user } = this.props;

        const place = event.queue.userQueues.sort((a,b) => {
            var dateA = new Date(a.startDate);
            var dateB = new Date(b.startDate);
            return dateA - dateB;
        }).findIndex(e => e.userId === user.id) + 1;

        const props = {
            location: event.location,
            title: event.laboratoryWork.title,
            time: event.startDate,
            place
        };

        return <Event {...props} />;
    }
}

EventContainer.propTypes = {};

const mapStateToProps = (state, { id }) => ({
    user: state.user,
    event: state.mainpage.events[id]
});

export default connect(mapStateToProps)(EventContainer);
