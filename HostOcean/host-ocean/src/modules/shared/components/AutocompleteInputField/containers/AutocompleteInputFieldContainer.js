import React from 'react';
import { bindActionCreators } from "redux";
import { connect } from "react-redux";
import { change } from "redux-form";
import PropTypes from 'prop-types';
import deburr from 'lodash/deburr';

import Input from '../components/Input/index';
import Suggestion from '../components/Suggestion/index';
import AutocompleteInputField from "../components/AutocompleteInputField/index"

class AutocompleteInputFieldContainer extends React.Component {
  state = {
    single: '',
    suggestions: [],
  };

  getSuggestionValue(suggestion) {
    return suggestion.name;
  }

  getSuggestions(value) {
    const suggestionsList = this.props.suggestions

    const inputValue = deburr(value.trim()).toLowerCase();
    const inputLength = inputValue.length;
    let count = 0;

    const suggestions = suggestionsList;

    return inputLength === 0
      ? []
      : suggestions.filter(suggestion => {
        const keep =
          count < 5 && suggestion.name.slice(0, inputLength).toLowerCase() === inputValue;

        if (keep) {
          count += 1;
        }

        return keep;
      });
  }

  handleSuggestionsClearRequested = () => {
  };

  handleSuggestionsFetchRequested = ({ value }) => {
    this.setState({
      suggestions: this.getSuggestions(value),
    });
  };

  handleChange = propName => (event, { newValue }) => {
    const {name, formName} = this.props;

    this.props.change(formName, name, newValue)
    this.setState({
      [propName]: newValue
    });
  };

  render() {
    const {classes, title, name} = this.props;

    const autosuggestProps = {
      renderInputComponent : Input,
      renderSuggestion: Suggestion,
      suggestions: this.state.suggestions,
      onSuggestionsFetchRequested: this.handleSuggestionsFetchRequested,
      onSuggestionsClearRequested: this.handleSuggestionsClearRequested,
      getSuggestionValue: this.getSuggestionValue,
    };

    const inputProps = {
      value: this.state.single,
      onChange: this.handleChange('single'),
      classes,
      title,
      name
    }

    const props = {
      inputProps,
      autosuggestProps,
      classes
    }

    return (
      <AutocompleteInputField {...props} />
    );
  }
}

AutocompleteInputFieldContainer.propTypes = {
  classes: PropTypes.object.isRequired,
  change: PropTypes.func.isRequired
};

const mapStateToProps = state => ({
});

const mapDispatchToProps = dispatch => ({
  change: bindActionCreators(change, dispatch)
});

export default connect(
  mapStateToProps,
  mapDispatchToProps
)(AutocompleteInputFieldContainer);