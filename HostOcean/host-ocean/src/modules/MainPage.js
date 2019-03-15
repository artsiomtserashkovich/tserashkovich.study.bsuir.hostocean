import { Typography, withStyles, Button } from '@material-ui/core';
import * as React from 'react';
import { bindActionCreators } from 'redux';
import { connect } from 'react-redux';
import * as formsActions from './account/actions'

const styles = {
    root: {
        flexGrow: 1,
    },
};

class MainPageView extends React.Component {
    onClick = () => {
        const { actions } = this.props;
        console.log("click")
        actions.getPingRequest();
    }

    render() {
        return (
            <React.Fragment>
                <Typography align={"left"} variant={"h2"} >
                    Its Main Page
                </Typography>
                <Button onClick={this.onClick}>Test click</Button>
            </React.Fragment>
        );
    }
}

const mapStateToProps = () => ({
})

const mapDispatchToProps = (dispatch) => {
    return {
        actions: bindActionCreators(formsActions, dispatch)
    }
}

export const MainPage = withStyles(styles)(connect(mapStateToProps, mapDispatchToProps)(MainPageView))