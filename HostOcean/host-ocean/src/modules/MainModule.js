import { Switch, Route, withRouter } from "react-router";
import { MainRoutes } from './MainRoutes';
import * as React from 'react';

class MainModuleContainer extends React.Component {
    render() {
        const { match } = this.props;
        return(
            <Switch>
                {
                    MainRoutes.map((item,index) =>
                    (
                        <Route
                            path={ `${match.path}${item.path}` }
                            component={item.component}
                            exact={item.exact}
                            key={index}
                        />
                    ))
                }
            </Switch>
        );
    }
};

export const MainModule =  withRouter(MainModuleContainer);
