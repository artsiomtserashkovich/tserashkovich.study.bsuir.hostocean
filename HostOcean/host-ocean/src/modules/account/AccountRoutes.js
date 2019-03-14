import AccountSettingsContainer from "./containers/AccountSettingsContainer";
import LoginFormContainer from './containers/LoginFormContainer';
import RegisterFormContainer from './containers/RegisterFormContainer';

import * as urls from "./constants/urls"

export const AccountRoutes = [
    {
        path: urls.accountSettings,
        component: AccountSettingsContainer,
    },
    {
        path: urls.accountLogin,
        component: LoginFormContainer,
    },
    {
        path: urls.accountRegister,
        component: RegisterFormContainer,
    },
];
