import React, { Component } from "react";

export default class TollList extends Component {
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
              {this.props.data.map((item) => (
                <tr>
                  <td>1</td>
                  <td>{item.date.toString().substring(0, 10)}</td>
                  {displayCar ? <td>{item.regnr}</td> : null}
                  <td>{item.rate}</td>
                </tr>
              ))}
            </tbody>
          </table>
        </div>
      </>
    );
  }
}
