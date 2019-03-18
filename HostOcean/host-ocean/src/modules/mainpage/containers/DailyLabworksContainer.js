import React from "react";
import LabworksListContainer from "./LabworksListContainer";
import * as _ from 'lodash';
import { connect } from 'react-redux';
import { bindActionCreators } from 'redux';
import * as labworksActions from "./../actions/labworksActions";

class DailyLabworksContainer extends React.Component {
    componentDidMount() {
        const { getLabworksRequest, groupId } = this.props;

        getLabworksRequest({ groupId });
    }

    render() {
        const { laboratoryWorks } = this.props;
        const groupedByDayLabs = _.groupBy(laboratoryWorks, e => {
            return new Date(e.startDate).toLocaleDateString('en-EN', {
                year: 'numeric',
                month: 'numeric',
                day: 'numeric'
            })
        });

        const labs = []
        for (var key in groupedByDayLabs) {
            labs.push({ date: key, laboratoryWorks: groupedByDayLabs[key] })
        }

        return labs.map((lab, index) => <LabworksListContainer key={index} {...lab} />);
    }
}

const mapStateToProps = (state) => {
    return ({
        laboratoryWorks: state.mainpage.labworks,
        groupId: state.user.groupId
    });
}

const mapDispatchToProps = (dispatch) => {
    return ({ ...bindActionCreators({ ...labworksActions }, dispatch) });
}

export default connect(mapStateToProps, mapDispatchToProps)(DailyLabworksContainer);