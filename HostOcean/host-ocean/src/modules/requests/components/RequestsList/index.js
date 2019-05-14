import React from "react";
import PropTypes from "prop-types";
import { withStyles } from "@material-ui/core";

import styles from "./styles";
import * as _ from "lodash";
import RequestContainer from "../../containers/RequestContainer";

const RequestsList = ({ classes, requests }) => {
    return (
        <div className={classes.container}>
            { _.map(requests, (request, index) => (
                <RequestContainer
                    key={index}
                    requestId={request.id}
                />
            ))}
        </div>
    );
};

RequestsList.propTypes = {
    classes: PropTypes.object.isRequired,
    requests: PropTypes.array.isRequired
};

export default withStyles(styles)(RequestsList);
