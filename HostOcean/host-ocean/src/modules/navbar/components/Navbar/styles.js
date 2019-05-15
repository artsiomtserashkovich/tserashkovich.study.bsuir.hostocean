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
        main: {
            display: "flex",
            justifyContent: "start",
            alignItems: "center"
        },
        link: {
            textDecoration: "none",
            color: "inherit",
            marginRight: 40
        },
        sidebar: {
            display: "none",
            "@media (max-width: 768px)": {
                display: "block"
            },
        },
        items: {
            display: "flex",
            "@media (max-width: 768px)": {
                display: "none"
            },
        }
    };
};
