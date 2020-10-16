import React, { Component } from "react";

import Menu from "./menu/menu";
import SavedReports from "./savedReports/savedReports";

export default class SidebarNavigation extends Component {
  render() {
    return (
      <nav
        id="sidebarMenu"
        className="col-md-3 col-lg-2 d-md-block bg-light sidebar collapse"
      >
        <div className="sidebar-sticky pt-3">
          <Menu />
          <SavedReports />
        </div>
      </nav>
    );
  }
}
