import React from "react";
import { withStyles, WithStyles} from "@material-ui/core/styles/index"
import { createStyles,
    Theme, Toolbar, IconButton, Typography,
    Button, AppBar } from "@material-ui/core";
import MenuIcon from '@material-ui/icons/Menu';

const styles = (theme: Theme) => createStyles({
    root: {
      flexGrow: 1,
    },
    grow: {
      flexGrow: 1,
    },
    menuButton: {
      marginLeft: -12,
      marginRight: 20,
    },
});

interface Props extends WithStyles<typeof styles> {

}

class NavBarComponent extends React.Component<Props> {
    public render() {
        const {classes} = this.props;
        return(
            <div className={classes.root}>
                <AppBar position="static">
                    <Toolbar>
                        <IconButton className={classes.menuButton} color="inherit" aria-label="Menu">
                            <MenuIcon/>
                        </IconButton>
                        <Typography variant="h6" color="inherit" className={classes.grow}>
                            Host Ocean
                        </Typography>
                        <Button color="inherit">Login</Button>
                    </Toolbar>
                </AppBar>
            </div>
        );
    }
}

export const NavBar = withStyles(styles)(NavBarComponent);