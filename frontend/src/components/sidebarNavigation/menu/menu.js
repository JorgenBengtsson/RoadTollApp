import React, { Component } from "react";

export default class Menu extends Component {
  render() {
    return (
      <ul className="nav flex-column">
        <li className="nav-item">
          <a className="nav-link active">
            <span data-feather="home"></span>
            Dashboard <span className="sr-only">(current)</span>
          </a>
        </li>
        <li className="nav-item">
          <a className="nav-link">
            <span data-feather="file"></span>
            Orders
          </a>
        </li>
        <li className="nav-item">
          <a className="nav-link">
            <span data-feather="shopping-cart"></span>
            Products
          </a>
        </li>
        <li className="nav-item">
          <a className="nav-link">
            <span data-feather="users"></span>
            Customers
          </a>
        </li>
        <li className="nav-item">
          <a className="nav-link">
            <span data-feather="bar-chart-2"></span>
            Reports
          </a>
        </li>
        <li className="nav-item">
          <a className="nav-link">
            <span data-feather="layers"></span>
            Integrations
          </a>
        </li>
      </ul>
    );
  }
}
