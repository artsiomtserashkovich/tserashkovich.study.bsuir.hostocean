export default theme => {
    return {
        root: {
            flexGrow: 1
        },
        grow: {
            flexGrow: 1
        },
        menuButton: {
            marginLeft: -12,
            marginRight: 20
        },
        color: {
            background: "red"
        },
        toolbar: {
            display: "flex",
            justifyContent: "space-between",
            background: theme.palette.background.paper,
            color: theme.palette.text.primary
        },
        link: {
            textDecoration: "none",
            color: "inherit"
        }
    };
};
