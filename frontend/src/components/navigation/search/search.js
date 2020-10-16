import React, { Component } from "react";

export default class Search extends Component {
  constructor() {
    super();
    this.state = { text: "" };
  }
  render() {
    return (
      <input
        className="form-control form-control-dark w-100"
        type="text"
        placeholder="Search"
        aria-label="Search"
        maxLength={6}
        value={this.state.text}
        onChange={(e) => {
          this.setState({ text: e.target.value });
          this.props.handleChange(e.target.value);
        }}
      />
    );
  }
}
