import * as React from 'react';
import { connect } from 'react-redux';

import PropTypes from 'prop-types';
import { Typography } from '@material-ui/core';

import UserCard from '../components/UserCard'

class UserCardContainer extends React.Component {
    render() {
        const {user} = this.props;
        console.log(user)

        return <UserCard />
    }
}

UserCardContainer.propTypes = {
    user: PropTypes.object.isRequired
}

const mapStateToProps = (state) => ({
    user: state.user
});

const mapDispatchToProps = (dispatch) => ({
});

export default connect(
    mapStateToProps,
    mapDispatchToProps
)(UserCardContainer);
