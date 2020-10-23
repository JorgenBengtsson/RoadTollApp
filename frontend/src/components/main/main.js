import React, { Component } from "react";
import Modal from "react-awesome-modal";

import "./main.css";

import { getAllToll } from "./../../fetch/fetch";
import { months } from "./../../utilities/dateUtilities";
import TollList from "./tollList/tollList";
import Dashboard from "./dashboard/dashboard";
import { filterItemOnMonth } from "../../utilities/filterUtilities";

export default class Main extends Component {
  constructor(props) {
    super(props);
    this.state = {
      data: [],
      dataFiltered: [],
      monthFilter: months[0],
      searchText: props.searchText,
      loadModalVisible: false,
    };
  }
  componentDidMount() {
    this.setState(
      { loadModalVisible: true },
      this.fetchAllData(() => this.setState({ loadModalVisible: false }))
    );
  }
  componentDidUpdate(prevProp) {
    if (prevProp.searchText !== this.props.searchText) {
      this.setState({ searchText: this.props.searchText });
    }
  }
  fetchAllData(callback) {
    getAllToll().then((json) =>
      this.setState({ data: json }, () =>
        this.filterData(this.state.monthFilter, this.state.searchText, callback)
      )
    );
  }
  filterData(month, regnr, callback) {
    var res = this.state.data.filter((item) => filterItemOnMonth(item, month));
    this.setState({ dataFiltered: res }, callback);
  }
  render() {
    return (
      <main role="main" className="col-md-9 ml-sm-auto col-lg-10 px-md-4">
        <Dashboard
          data={this.state.dataFiltered}
          title="Dashboard"
          handleMonthFilter={(item) => {
            this.setState({ monthFilter: item, loadModalVisible: true }, () =>
              this.filterData(item, this.state.searchText, () =>
                this.setState({ loadModalVisible: false })
              )
            );
          }}
        />
        <TollList data={this.state.dataFiltered} />
        <Modal
          visible={this.state.loadModalVisible}
          width="400"
          height="90"
          effect="fadeInUp"
          onClickAway={() => this.closeModal()}
        >
          <div className="loadDataModule">
            <h1>Loading data...</h1>
          </div>
        </Modal>
      </main>
    );
  }
}
