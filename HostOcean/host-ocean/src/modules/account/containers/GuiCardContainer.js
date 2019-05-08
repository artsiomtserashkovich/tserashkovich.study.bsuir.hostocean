import * as React from "react";
import { connect } from "react-redux";

import GuiCard from "../components/GuiCard";
import * as uiActions from "../../ui/actions";
import { bindActionCreators } from "redux";

class GuiCardContainer extends React.Component {
    changeColorTheme = (event, isDarkThemeEnabled) => {
        const { changeColorScheme } = this.props
        const theme = isDarkThemeEnabled ? "dark" : "light";
        
        changeColorScheme(theme);
    }

    render() {
        const { isDarkThemeEnabled } = this.props

        const props = {
            changeColorTheme: this.changeColorTheme,
            isDarkThemeEnabled
        };

        return <GuiCard {...props} />;
    }
}

GuiCardContainer.propTypes = {};

const mapStateToProps = state => ({
    isDarkThemeEnabled: state.ui.colorScheme === "dark"
});

const mapDispatchToProps = dispatch => ({
    ...bindActionCreators(uiActions, dispatch)
});

export default connect(
    mapStateToProps,
    mapDispatchToProps
)(GuiCardContainer);
