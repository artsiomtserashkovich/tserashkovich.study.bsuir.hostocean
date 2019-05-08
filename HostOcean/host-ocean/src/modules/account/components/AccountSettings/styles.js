const styles = theme => ({
    root: {
        width: 900,
        margin: "auto",
        "@media (max-width: 900px)": {
            width: "inherit"
        },
        marginBottom: 10
    },
    main: {
        display: "flex",
        "@media (max-width: 900px)": {
            flexFlow: "wrap"
        },
        "@media (max-width: 512px)": {
            flexDirection: "column"
        }
    },
    mid: {
        dislpay: "flex",
        flexDirection: "column",
        flexGrow: 1
    }
});

export default styles;
