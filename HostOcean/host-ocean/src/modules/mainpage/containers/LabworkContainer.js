import React from "react";
import { connect } from 'react-redux';

import Labwork from "./../components/Labwork"

class LabworkContainer extends React.Component {
    render() {
        const { labwork, location, startDate } = this.props;

        const props = {
            ...labwork,
            location,
            startDate
        }

        return <Labwork {...props} />;
    }
}

const mapStateToProps = (state, props) => {
    return ({
        labwork: state.mainpage.labworks[props.labworkId],
        location: state.mainpage.events[props.eventId].location,
        startDate: state.mainpage.events[props.eventId].startDate
    });
}

const mapDispatchToProps = (dispatch, props) => {
    return ({});
}

export default connect(mapStateToProps, mapDispatchToProps)(LabworkContainer);