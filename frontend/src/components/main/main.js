import React, { Component } from "react";

import {
  getAllTollPassByMonth,
  getAllTollPassByMonthAndCar,
} from "./../../fetch/fetch";
import { months, monthToNumber } from "./../../utilities/dateUtilities";

import TollList from "./tollList/tollList";
import Dashboard from "./dashboard/dashboard";

export default class Main extends Component {
  constructor(props) {
    super(props);
    this.state = {
      data: [],
      monthFilter: months[0],
      searchText: props.searchText,
    };
  }
  componentDidMount() {
    this.fetchData(this.state.monthFilter, this.state.searchText);
  }
  componentDidUpdate(prevProp) {
    if (prevProp.searchText !== this.props.searchText) {
      this.setState({ searchText: this.props.searchText });
      this.fetchData(this.state.monthFilter, this.props.searchText);
    }
  }
  fetchData(month, regnr) {
    console.log("fetch", regnr);
    if (regnr.length === 6) {
      getAllTollPassByMonthAndCar(monthToNumber(month), regnr).then((json) =>
        this.setState({ data: json })
      );
    } else {
      getAllTollPassByMonth(monthToNumber(month)).then((json) =>
        this.setState({ data: json })
      );
    }
  }
  render() {
    return (
      <main role="main" className="col-md-9 ml-sm-auto col-lg-10 px-md-4">
        <Dashboard
          data={this.state.data}
          title="Dashboard"
          handleMonthFilter={(item) => {
            this.setState({ monthFilter: item });
            this.fetchData(item, this.state.searchText);
          }}
        />
        <TollList data={this.state.data} />
      </main>
    );
  }
}
