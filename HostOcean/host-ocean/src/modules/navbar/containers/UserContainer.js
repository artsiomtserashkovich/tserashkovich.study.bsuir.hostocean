import React from "react";
import { connect } from 'react-redux';

import User from "../components/User"

class UserContainer extends React.Component {
    constructor(props) {
        super(props);
        this.state = {
            anchorEl: null
        };
    }

    handleClose = () => {
        this.setState({ anchorEl: null });
    };

    handleMenu = event => {
        this.setState({ anchorEl: event.currentTarget });
    };

    render() {
        const { user } = this.props;
        const { anchorEl } = this.state;

        const props = {
            user,
            anchorEl,
            handleMenu: this.handleMenu,
            handleClose: this.handleClose,
            open: Boolean(anchorEl)
        }

        return <User {...props} />;
    }
}

const mapStateToProps = (state, props) => {
    return ({
        user: state.user,
    });
}

const mapDispatchToProps = (dispatch, props) => {
    return ({});
}

export default connect(mapStateToProps, mapDispatchToProps)(UserContainer);