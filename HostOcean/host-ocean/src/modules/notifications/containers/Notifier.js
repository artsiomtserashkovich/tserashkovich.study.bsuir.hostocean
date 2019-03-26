import { Component } from 'react';
import { bindActionCreators } from 'redux';
import { connect } from 'react-redux';
import { withSnackbar } from 'notistack';
import { removeSnackbar } from './../actions/index';

class Notifier extends Component {
    displayed = [];

    storeDisplayed = (id) => {
        this.displayed = [...this.displayed, id];
    };

    shouldComponentUpdate({ notifications: newSnacks = [] }) {
        const { notifications: currentSnacks } = this.props;
        let notExists = false;
        for (let i = 0; i < newSnacks.length; i += 1) {
            if (notExists) continue;
            notExists = notExists || !currentSnacks.filter(({ key }) => newSnacks[i].key === key).length;
        }
        return notExists;
    }

    componentDidUpdate() {
        const { notifications = [] } = this.props;

        notifications.forEach((notification) => {
            if (this.displayed.includes(notification.key)) return;
            
            this.props.enqueueSnackbar(notification.message, notification.options);
            this.storeDisplayed(notification.key);
            this.props.removeSnackbar(notification.key);
        });
    }

    render() {
        return null;
    }
}

const mapStateToProps = store => ({
    notifications: store.app.notifications,
});

const mapDispatchToProps = dispatch => bindActionCreators({ removeSnackbar }, dispatch);

export default connect(
    mapStateToProps,
    mapDispatchToProps,
)(withSnackbar(Notifier));