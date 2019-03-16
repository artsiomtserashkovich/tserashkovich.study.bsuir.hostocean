import React from "react";
import { connect } from 'react-redux';

import Labwork from "./../components/Labwork"

class LabworkContainer extends React.Component {
    render() {
        const { labwork } = this.props;

        return <Labwork {...labwork} />;
    }
}

const mapStateToProps = (state, props) => {
    return ({
        labwork: state.mainpage.labworks[props.id]
    });
}

const mapDispatchToProps = (dispatch, props) => {
    return ({});
}

export default connect(mapStateToProps, mapDispatchToProps)(LabworkContainer);