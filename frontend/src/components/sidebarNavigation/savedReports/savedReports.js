import React, { Component } from "react";

export default class SavedReports extends Component {
  render() {
    return (
      <>
        <h6 className="sidebar-heading d-flex justify-content-between align-items-center px-3 mt-4 mb-1 text-muted">
          <span>Saved reports</span>
          <a
            className="d-flex align-items-center text-muted"
            aria-label="Add a new report"
          >
            <span data-feather="plus-circle"></span>
          </a>
        </h6>
        <ul className="nav flex-column mb-2">
          <li className="nav-item">
            <a className="nav-link">
              <span data-feather="file-text"></span>
              Current month
            </a>
          </li>
          <li className="nav-item">
            <a className="nav-link">
              <span data-feather="file-text"></span>
              Last quarter
            </a>
          </li>
          <li className="nav-item">
            <a className="nav-link">
              <span data-feather="file-text"></span>
              Social engagement
            </a>
          </li>
          <li className="nav-item">
            <a className="nav-link">
              <span data-feather="file-text"></span>
              Year-end sale
            </a>
          </li>
        </ul>
      </>
    );
  }
}
