import { withRouter, Switch, Route } from 'react-router';
import { AccountRoutes } from './AccountRoutes';
import * as React from 'react';

class AccountModuleContainer extends React.Component {
    render() {
        const { match } = this.props;

        return (
            <Switch>
                {
                    AccountRoutes.map((item, index) =>
                        (
                            <Route
                                key={index}
                                path={`${match.path}/${item.path}`}
                                component={item.component}
                                exact={item.exact}
                            />
                        ))
                }
            </Switch>
        );
    }
};

export const AccountModule = withRouter(AccountModuleContainer);
