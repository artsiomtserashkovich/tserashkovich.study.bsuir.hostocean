import React from "react";
import { withStyles, WithStyles} from "@material-ui/core/styles/index"
import { createStyles,
    Toolbar, IconButton, Typography,
    Button, AppBar } from "@material-ui/core";

import { library } from '@fortawesome/fontawesome-svg-core'
import { FontAwesomeIcon } from '@fortawesome/react-fontawesome'
import { faIgloo, faHome, faSignInAlt } from '@fortawesome/free-solid-svg-icons'


library.add(faSignInAlt)

const styles = createStyles({
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
    color:{
        background: "red",
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
                        <img src={"https://psv4.userapi.com/c848336/u209976673/docs/d9/13f1e43d7a76/logo.png?extra=QdHWDJRKzIXY3UOpvXRHcloa5W7GynHjnAgWIfv9p3eYfHRZuYBN0r542vP97OzB_piq2Nnofhs9nhkGW6ixx0T7gYSsZW5PHAI_igFszFak5fYrP2CpsSaJDjYSCSFDGMZ0oIYm_HebyM5iwQnG2kM"} width={"70px"} height={"60px"}/>
                  
                        <Typography variant="h6" color="inherit" className={classes.grow}>
                            HostOcean
                        </Typography>
                        <Button color="inherit">Login   <FontAwesomeIcon icon="sign-in-alt"/></Button>
                        
   
                    </Toolbar>
                </AppBar>
            </div>
        );
    }
}

export const NavBar = withStyles(styles)(NavBarComponent);
