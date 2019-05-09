import { Typography } from "@material-ui/core";
import { Link } from "react-router-dom";
import PropTypes from 'prop-types';
import React from 'react';
import { withStyles } from '@material-ui/core/styles';
import styles from "./styles";

function LabelLink(props) {
    const { classes, to, label, primary } = props;

    return (
      <Typography variant="h6">
        <Link to={to} className={primary ? classes.primary : classes.secondary}>
            {label}
        </Link>
      </Typography>
    );
  }

LabelLink.propTypes = {
    classes: PropTypes.object.isRequired,
    to: PropTypes.string,
    label: PropTypes.string,
    primary: PropTypes.bool,
};

export default withStyles(styles)(LabelLink);
