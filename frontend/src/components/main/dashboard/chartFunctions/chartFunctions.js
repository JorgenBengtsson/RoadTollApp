import React, { Component } from "react";

export default class ChartFunctions extends Component {
  render() {
    return (
      <div className="btn-group mr-2">
        <button type="button" className="btn btn-sm btn-outline-secondary">
          Share
        </button>
        <button type="button" className="btn btn-sm btn-outline-secondary">
          Export
        </button>
      </div>
    );
  }
}
