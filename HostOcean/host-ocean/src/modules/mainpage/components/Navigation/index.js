import React from 'react';
import { Link } from "react-router-dom";

const Navigation = () => {
    return (
        <div>
            <Link to="statistic">Cтатистика</Link>
            <Link to="queue">Текущая очередь</Link>
            <Link to="setting">Настройки</Link>
        </div>
    );
}

export default Navigation;