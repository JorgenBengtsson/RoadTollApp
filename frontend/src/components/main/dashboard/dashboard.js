import React, { Component } from "react";

import Chart from "./chart/chart";
import ChartFunctions from "./chartFunctions/chartFunctions";
import MonthFilter from "./monthFilter/monthFilter";

export default class Dashboard extends Component {
  render() {
    return (
      <>
        <div className="d-flex justify-content-between flex-wrap flex-md-nowrap align-items-center pt-3 pb-2 mb-3 border-bottom">
          <h1 className="h2">{this.props.title}</h1>
          <div className="btn-toolbar mb-2 mb-md-0">
            <ChartFunctions />
            <MonthFilter
              handleSelect={(item) => this.props.handleMonthFilter(item)}
            />
          </div>
        </div>
        <Chart data={this.props.data} />
      </>
    );
  }
}
