import * as React from "react";
import { connect } from "react-redux";

import CompletenessCard from "../components/CompletenessCard";

class CompletenessCardContainer extends React.Component {
    render() {
        const { user } = this.props;

        let totalFields = 0,
            filledFields = 0;

        for (var key in user) {
            if (user[key] instanceof Object) continue;
            
            totalFields++;
            if (user[key]) {
                filledFields++;
            }
        }

        const props = {
            completeness: Math.floor((filledFields * 100) / totalFields)
        };

        return <CompletenessCard {...props} />;
    }
}

CompletenessCardContainer.propTypes = {};

const mapStateToProps = state => ({
    user: state.user
});

const mapDispatchToProps = dispatch => ({});

export default connect(
    mapStateToProps,
    mapDispatchToProps
)(CompletenessCardContainer);
