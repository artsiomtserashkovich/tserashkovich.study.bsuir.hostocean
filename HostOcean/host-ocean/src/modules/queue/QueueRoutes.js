import { QueueList } from "./QueueList/QueueList";
import { QueueChoose } from './QueueChoose/QueueChoose';

export const QueueRoutes = [
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
