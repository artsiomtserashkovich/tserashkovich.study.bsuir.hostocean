import { Typography } from "@material-ui/core";
import { Link } from "react-router-dom";
import PropTypes from 'prop-types';
import React from 'react';
import { withStyles } from '@material-ui/core/styles';
import styles from "./styles";

function LabelLink(props) {
    const { classes, to, label } = props;

    return (
      <Typography variant="h6" color="primary" className={classes.grow}>
        <Link to={to} color="primary" className={classes.link}>
            {label}
        </Link>
      </Typography>
    );
  }

LabelLink.propTypes = {
    classes: PropTypes.object.isRequired,
    to: PropTypes.string,
    label: PropTypes.string,
};

export default withStyles(styles)(LabelLink);
