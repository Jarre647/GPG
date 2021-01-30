import React from 'react';
import { render } from 'react-dom';
import PropTypes from "prop-types";

class Counter extends React.Component {
    static propTypes = {
        incrementBy: PropTypes.number,
        onIncremen: PropTypes.func.isRequired
    };
    static defaultProps = {
      incrementBy: 1
    };

    constructor(props) {
      super(props);
      this.state = {
        count: 0
      };
      this.onButtonClick = this.onButtonClick.bind(this);
    }
    onButtonClick() {
      this.setState(function(prevState, props) {
        return { count: prevState.count + props.incrementBy};
      });
    }
    render() {
      return (
        <div>
          <h1>
            {this.state.count}
            <button onClick={this.onButtonClick}>++</button>
          </h1>
        </div>
      )
    }
}
render (<Counter incrementBy={1}/>, document.getElementById('root'))