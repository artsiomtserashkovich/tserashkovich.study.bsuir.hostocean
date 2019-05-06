const styles = theme => ({
  card: {
    padding: 10,
    width: 300
  },
  header: {
    display: "flex",
    flexDirection: "row",
    alignItems: "center",
    justifyContent: "space-between"
  },
  body: {
    marginTop: 10,
    display: "flex",
    flexDirection: "row"
  },
  fields: {
    display: "flex",
    flexDirection: "column",
    flexGrow: 1
  },
  textField: {
    marginBottom: 10
  }
});

export default styles;
