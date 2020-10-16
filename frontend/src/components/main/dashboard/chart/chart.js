import React, { Component } from "react";
import "./../../../../../node_modules/react-vis/dist/style.css";
import {
  XYPlot,
  XAxis,
  YAxis,
  VerticalGridLines,
  HorizontalGridLines,
  VerticalBarSeries,
} from "react-vis";

export default class Chart extends Component {
  constructor() {
    super();
    this.state = {
      data: [],
    };
  }
  componentDidUpdate(prevProps) {
    if (prevProps.data !== this.props.data)
      this.setState({ data: this.props.data });
  }
  compileData() {
    var data = [];
    for (let index = 1; index <= 31; index++) {
      data.push({ x: index, y: 0 });
    }
    this.state.data.forEach((t) => {
      var date = new Date(t.date);
      var day = date.getDate();
      data.forEach((e) => {
        if (e.x === day) e.y += 1;
      });
    });
    return data;
  }
  render() {
    var data = this.compileData();
    if (data.length > 0) {
      return (
        <XYPlot xType="ordinal" width={900} height={380} xDistance={20}>
          <VerticalGridLines />
          <HorizontalGridLines />
          <XAxis />
          <YAxis />
          <VerticalBarSeries data={data} />
        </XYPlot>
      );
    } else {
      return null;
    }
  }
}
