import * as React from 'react';
import MainPage from "./../components/MainPage/index";

const accountStab = {
    name: "Polina",
    surname: "Noname",
    groupId: 650502,
}

class MainPageContainer extends React.Component {
    render() {
        const props = {
            accountAbout: accountStab
        }

        return <MainPage {...props}/>;
    }
}

export default MainPageContainer;