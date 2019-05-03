import MomentUtils from '@date-io/moment';
import * as React from 'react';
import PropTypes from "prop-types";
import { MuiPickersUtilsProvider } from 'material-ui-pickers';

export default class MUIMomentDatePickerProvider extends React.Component {
    render(){
        const { children, locale } = this.props;

        return(
            <MuiPickersUtilsProvider utils={MomentUtils} locale={locale}>
                {children}
            </MuiPickersUtilsProvider>
        )
    }
}

MuiPickersUtilsProvider.propTypes = {
    children: PropTypes.any.isRequired,
    locale: PropTypes.string.isRequired,
};

