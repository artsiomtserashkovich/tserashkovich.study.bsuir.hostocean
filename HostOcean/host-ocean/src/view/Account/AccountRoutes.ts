import { AccountSettings } from "./Settings/AccountSettings";
import { AccountLogin } from './Login/AccountLogin';
import { AccountRegister } from './Register/AccountRegister';
import { IRoute } from '../../typings';

export const AccountRoutes: IRoute[] = [
    {
        path: "",
        component: AccountSettings,
    },
    {
        path: "login",
        component: AccountLogin,
    },
    {
        path: "register",
        component: AccountRegister,
    },
];
