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
        let { laboratoryWorks } = this.props;

        const groupedByDayLabs = _.groupBy(laboratoryWorks, e => {
            console.log(Date(e.startDate));
            return new Date(e.startDate).toLocaleDateString('en-EN', {
                year: 'numeric',
                month: 'numeric',
                day: 'numeric'
            })
        });

        let labs = []
        for (var key in groupedByDayLabs) {
            labs.push({ date: key, laboratoryWorks: groupedByDayLabs[key] })
        }
        labs = labs.sort((a, b) => {
            if (a.date > b.date) {
                return 1;
            }
            if (a.date < b.date) {
                return -1;
            }
            return 0;
        });

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