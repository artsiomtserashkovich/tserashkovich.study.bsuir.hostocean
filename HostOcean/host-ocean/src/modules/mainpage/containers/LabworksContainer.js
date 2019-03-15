import React from "react";
import LaboratoryWorks from "../components/Labwork";

const LaboratoryWorkSubGroup = ({
    Common: 0,
    First: 1,
    Second: 2
})

const labsStab = [
    {
        id: "1",
        title: "АКСиС",
        date: new Date(),
        description: undefined,
        subGroup: LaboratoryWorkSubGroup.Common,
        groupId: 650502,
    },{
        id: "2",
        title: "СА",
        date: new Date(),
        description: undefined,
        subGroup: LaboratoryWorkSubGroup.Common,
        groupId: 650502,
    },{
        id: "3",
        title: "АВП",
        date: new Date(),
        description: undefined,
        subGroup: LaboratoryWorkSubGroup.Common,
        groupId: 650502,
    }
]


export class LabworksContainer extends React.Component {
    constructor(props) {
        super(props);
        this.state = {
            laboratoryWorks: [],
        };
    }
    componentDidMount() {
        this.setState({
            laboratoryWorks: labsStab,
        });
    }
    render() {
        const { laboratoryWorks } = this.state;

        const props = {
            laboratoryWorks
        }

        return <LaboratoryWorks {...props}/>
    }
}

export default LabworksContainer;