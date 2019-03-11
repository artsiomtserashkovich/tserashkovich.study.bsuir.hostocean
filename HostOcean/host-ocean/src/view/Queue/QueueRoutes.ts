import { QueueList } from "./QueueList/QueueList";
import { QueueChoose } from './QueueChoose/QueueChoose';
import { IRoute } from '../../typings';

export const QueueRoutes: IRoute[] = [
    {
        path: "",
        component: QueueList,
        exact: true
    },
    {
        path: "choose",
        component: QueueChoose,
    },
];
