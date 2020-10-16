import React, { Component } from "react";

import { months } from "./../../../../utilities/dateUtilities";

export default class MonthFilter extends Component {
  constructor() {
    super();
    this.state = { selectedMonth: months[0] };
  }
  render() {
    return (
      <div className="dropdown">
        <button
          className="btn btn-secondary dropdown-toggle"
          type="button"
          id="dropdownMenuButton"
          data-toggle="dropdown"
          aria-haspopup="true"
          aria-expanded="false"
        >
          {this.state.selectedMonth}
        </button>
        <div className="dropdown-menu" aria-labelledby="dropdownMenuButton">
          {months.map((item) => (
            <a
              onClick={() => {
                this.setState({ selectedMonth: item });
                this.props.handleSelect(item);
              }}
              className="dropdown-item"
              href="#"
            >
              {item}
            </a>
          ))}
        </div>
      </div>
    );
  }
}
