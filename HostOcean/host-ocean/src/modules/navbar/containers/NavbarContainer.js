import React from "react";
import { connect } from 'react-redux';

import Navbar from "../components/Navbar"

class NavbarContainer extends React.Component {
    render() {
        const { labwork } = this.props;

        return <Navbar {...labwork} />;
    }
}

const mapStateToProps = (state, props) => {
    return ({});
}

const mapDispatchToProps = (dispatch, props) => {
    return ({});
}

export default connect(mapStateToProps, mapDispatchToProps)(NavbarContainer);
