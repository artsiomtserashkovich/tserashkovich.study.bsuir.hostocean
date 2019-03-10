import { withRouter, RouteComponentProps, Switch, Route } from 'react-router';
import { AccountRoutes } from './AccountRoutes';
import * as React from 'react';

interface Props extends RouteComponentProps{
}

class AccountModuleContainer extends React.Component<Props> {
    public render() {
        const { match } = this.props;
        return(
            <Switch>
                {
                    AccountRoutes.map((item) =>
                    (
                        <Route
                            path={ `${match.url}/${item.path}` }
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
