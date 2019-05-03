import PropTypes from 'prop-types';
import React from 'react';
import styles from "./styles";
import { InlineDatePicker } from "material-ui-pickers";
import { Paper, Button, withStyles, Grid } from "@material-ui/core";

const formName = "statistics";

function StatisticsFormContainer(props) {
    const { classes } = props;
    return (
        <form>
            <Paper className={classes.paper}>
                <Grid 
                    container 
                    spacig={8}
                    direction="row"
                    alignContent={"flex-end"}
                    className={classes.gridContainer}
                >
                    <Grid item lg={1}/>
                    <Grid item lg={2} md={4} xs={12}>
                        <InlineDatePicker
                            label="Start Period"
                            value={new Date()}
                            onChange={() => new Date()}
                        />
                    </Grid>
                    <Grid item lg={2} md={4} xs={12}> 
                        <InlineDatePicker
                            label="End Period"
                            value={new Date()}
                            onChange={() => new Date()}
                        />
                    </Grid>
                    <Grid item lg={2} md={4} xs={12}>
                        <Button variant="outlined">
                            Get Statistic
                        </Button>
                    </Grid>
                </Grid>
            </Paper>
        </form>
    );
}

StatisticsFormContainer.propTypes = {
    classes: PropTypes.object.isRequired,
}

export default withStyles(styles)(StatisticsFormContainer);
