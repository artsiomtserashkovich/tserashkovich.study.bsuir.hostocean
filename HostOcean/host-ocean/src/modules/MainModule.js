import { Switch, Route, withRouter } from "react-router";
import { MainRoutes } from './MainRoutes';
import * as React from 'react';

import AuthorizedControl from "./authorizedControl";
import Notifier from "./notifications/containers/Notifier";

class MainModuleContainer extends React.Component {
    render() {
        const { match } = this.props;
        return (
            <React.Fragment>
                <Notifier/>
                <Switch>
                    {
                        MainRoutes.map((item, index) => {
                            const props = {
                                path: `${match.url}${item.path}`,
                                component: item.component,
                                exact: item.exact,
                                key: index
                            };

                            return item.requireAuth ? <AuthorizedControl {...props} /> : <Route {...props} />
                        })
                    }
                </Switch>
            </React.Fragment>
        );
    }
};

export const MainModule = withRouter(MainModuleContainer);
