import * as React from "react";
import { connect } from "react-redux";
import { CssBaseline, MuiThemeProvider } from "@material-ui/core";

import { ConnectedRouter } from "connected-react-router";
import { ReactReduxContext } from "react-redux";

import { history } from "./state";

import { MainModule } from "./modules/MainModule";

import NavbarContainer from "./modules/navbar/containers/NavbarContainer";

import { createMuiTheme } from "@material-ui/core/styles";

class UI extends React.Component {
    render() {
        const { ui } = this.props;

        const theme = createMuiTheme({
            palette: {
                type: ui.colorScheme
            }
        });

        return (
            <MuiThemeProvider theme={theme}>
                <ConnectedRouter history={history} context={ReactReduxContext}>
                    <React.Fragment>
                        <CssBaseline />
                        <NavbarContainer />
                        <MainModule />
                        {/* <Footer /> */}
                    </React.Fragment>
                </ConnectedRouter>
            </MuiThemeProvider>
        );
    }
}

const mapStateToProps = state => ({
    ui: state.ui
});

const mapDispatchToProps = dispatch => ({});

export default connect(
    mapStateToProps,
    mapDispatchToProps
)(UI);
