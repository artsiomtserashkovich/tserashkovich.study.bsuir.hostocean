import React from "react";
import { bindActionCreators } from 'redux';
import { connect } from 'react-redux';
import * as _ from 'lodash';

import EventsList from "../components/EventsList/index";

import * as eventsActions from "../actions/eventsActions";

class DailyEventsContainer extends React.Component {
    componentDidMount() {
        const { getEventsRequest, groupId } = this.props;

        getEventsRequest({ groupId });
    }

    render() {
        let { events } = this.props;

        const groupedByDayEvents = _.groupBy(events, e => {
            return new Date(e.startDate).toLocaleDateString('en-EN', {
                year: 'numeric',
                month: 'numeric',
                day: 'numeric'
            })
        });

        let eventGroups = []
        for (var key in groupedByDayEvents) {
            eventGroups.push({ date: key, events: groupedByDayEvents[key] })
        }
        
        eventGroups = eventGroups.sort((a, b) => {
            if (a.date > b.date) return 1;
            if (a.date < b.date) return -1;
            
            return 0;
        });

        return eventGroups.map((eventGroup, index) => {
            const options = { weekday: 'long', year: 'numeric', month: 'long', day: 'numeric' };

            const props = {
                date: new Date(eventGroup.date).toLocaleString('en-EN', options),
                events: eventGroup.events.sort((a, b) => {
                    if (a.startDate > b.startDate) return 1;
                    if (a.startDate < b.startDate) return -1;
                    return 0;
                })
            }

            return (<EventsList key={index} {...props} />)
        });
    }
}

const mapStateToProps = (state) => {
    return ({
        events: state.mainpage.events,
        groupId: state.user.groupId
    });
}

const mapDispatchToProps = (dispatch) => {
    return ({ ...bindActionCreators({ ...eventsActions }, dispatch) });
}

export default connect(mapStateToProps, mapDispatchToProps)(DailyEventsContainer);