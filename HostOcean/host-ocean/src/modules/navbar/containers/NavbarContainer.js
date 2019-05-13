import React from "react";
import { connect } from 'react-redux';

import Navbar from "../components/Navbar"

class NavbarContainer extends React.Component {
    constructor(props) {
        super(props);

        this.state = {
            isMenuOpened: false
        };
    }

    toggleMenu = () => {
        const { isMenuOpened } = this.state;
        this.setState({ isMenuOpened: !isMenuOpened })
    }

    render() {
        const { isMenuOpened } = this.state;

        const props = {
            isMenuOpened,
            toggleMenu: this.toggleMenu
        }

        return <Navbar {...props} />;
    }
}

const mapStateToProps = (state, props) => {
    return ({});
}

const mapDispatchToProps = (dispatch, props) => {
    return ({});
}

export default connect(mapStateToProps, mapDispatchToProps)(NavbarContainer);
