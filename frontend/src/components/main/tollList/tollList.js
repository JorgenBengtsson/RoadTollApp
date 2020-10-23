import React, { Component } from "react";

import EditToll from "./editToll/editToll";

export default class TollList extends Component {
  constructor() {
    super();
    this.state = { editModalVisible: false, selectedId: 0 };
  }
  render() {
    var displayCar =
      this.props.data.length > 0 ? this.props.data[0].regnr : false;
    return (
      <>
        <h2>Section title</h2>
        <div className="table-responsive">
          <table className="table table-striped table-sm">
            <thead>
              <tr>
                <th>#</th>
                <th>Date</th>
                {displayCar ? <th>Car</th> : null}
                <th>Rate</th>
              </tr>
            </thead>
            <tbody>
              {this.props.data.length > 0 ? (
                this.props.data.map((item) => (
                  <tr
                    key={item.id}
                    onClick={() =>
                      this.setState({
                        editModalVisible: true,
                        selectedId: item.id,
                      })
                    }
                  >
                    <td>1</td>
                    <td>{item.date.toString().substring(0, 10)}</td>
                    {displayCar ? <td>{item.regnr}</td> : null}
                    <td>{item.rate}</td>
                  </tr>
                ))
              ) : (
                <tr>
                  <td colSpan="3">No data loaded</td>
                </tr>
              )}
            </tbody>
          </table>
        </div>
        <EditToll
          modalVisible={this.state.editModalVisible}
          onClose={() =>
            this.setState({ editModalVisible: false, selectedId: 0 })
          }
          id={this.state.selectedId}
        />
      </>
    );
  }
  update() {
    fetch("https://localhost:44365/api/owners/1")
      .then((response) => {
        if (response.ok) {
          return response.json();
        } else {
          if (response.status == "404") {
            throw "Id not recoginzed";
          } else {
            throw "FEL";
          }
        }
      })
      .then((retObj) => {
        if (retObj.message) {
          this.setState({ fetchSuccess: retObj.message });
        }
      })
      .catch((e) => this.setState({ fetchError: e }));
  }
}
