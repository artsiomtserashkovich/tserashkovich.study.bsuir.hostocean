import React from "react";
import LabworksList from "../components/LabworksList";

export class LabworksListContainer extends React.Component {
    render() {
        const { laboratoryWorks, date } = this.props;

        const options = { weekday: 'long', year: 'numeric', month: 'long', day: 'numeric' };

        const props = {
            date: new Date(date).toLocaleString('en-EN', options),
            laboratoryWorks
        }

        return <LabworksList {...props} />
    }
}

export default LabworksListContainer;