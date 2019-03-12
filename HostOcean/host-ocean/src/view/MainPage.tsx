import { WithStyles, Typography, withStyles, Button } from '@material-ui/core';
import * as React from 'react';
import { bindActionCreators, Dispatch, AnyAction } from 'redux';
import { connect } from 'react-redux';
import * as formsActions from './Account/actions'

const styles = {
    root: {
        flexGrow: 1,
    },
};

interface Props extends WithStyles<typeof styles> {
    actions: {
        getPingRequest: () => any
    };
}

class MainPageView extends React.Component<Props> {
    onClick = () => {
        const { actions } = this.props;
        console.log("click")
        actions.getPingRequest();
    }

    public render() {
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

const mapDispatchToProps = (dispatch: Dispatch<AnyAction>) => {
    return {
        actions: bindActionCreators(formsActions, dispatch)
    }
}

export const MainPage = withStyles(styles)(connect(mapStateToProps, mapDispatchToProps)(MainPageView))