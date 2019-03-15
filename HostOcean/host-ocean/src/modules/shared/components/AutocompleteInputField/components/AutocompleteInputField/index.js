import React from 'react';
import PropTypes from 'prop-types';
import Autosuggest from 'react-autosuggest';
import Paper from '@material-ui/core/Paper';

const AutocompleteInputField = ({
  classes,
  autosuggestProps,
  inputProps,
  ...other
}) => {
  return (
    <Autosuggest
      {...autosuggestProps}
      inputProps={{ ...inputProps}}
      theme={{
        container: classes.container,
        suggestionsContainerOpen: classes.suggestionsContainerOpen,
        suggestionsList: classes.suggestionsList,
        suggestion: classes.suggestion,
      }}
      renderSuggestionsContainer={options => (
        <Paper {...options.containerProps} square>
          {options.children}
        </Paper>
      )}
      {...other}
    />
  );
};

AutocompleteInputField.propTypes = {
  classes: PropTypes.object.isRequired,
  autosuggestProps: PropTypes.object.isRequired,
  inputProps: PropTypes.object.isRequired
};

export default AutocompleteInputField;