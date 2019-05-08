const styles = theme => ({
    root: {
        marginLeft: 10,
        marginRight: 10,
        padding: 10
    },
    body: {
        display: "flex",
        justifyContent: "start",
        overflowX: "auto"
    },
    title: {
        display: "flex",
        flexDirection: "row",
        alignItems: "center",
        marginLeft: -10
    },
    avatar: {
        margin: theme.spacing.unit,
        backgroundColor: theme.palette.secondary.main
    },
    info: {
        margin: "auto",
        padding: 10
    }
});

export default styles;
