import React, { useState } from "react";

import "./App.css";

import Main from "./components/main/main";
import Navigation from "./components/navigation/navigation";
import SidebarNavigation from "./components/sidebarNavigation/sidebarNavigation";

function App() {
  const [searchText, updateSearchText] = useState("");
  return (
    <>
      <Navigation handleSearchChange={(text) => updateSearchText(text)} />
      <div className="container-fluid">
        <div className="row">
          <SidebarNavigation />
          <Main searchText={searchText} />
        </div>
      </div>
    </>
  );
}

export default App;
