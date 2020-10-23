import React, { Component } from "react";
import Modal from "react-awesome-modal";

import { getTollById, updateToll } from "../../../../fetch/fetch";
import "./editToll.css";

export default class EditToll extends Component {
  constructor(props) {
    super(props);
    this.state = {
      modalVisible: props.modalVisible,
      fetchStatus: 0,
      message: "",
      data: null,
      inputDate: "",
    };
  }
  componentDidUpdate(prevProp) {
    if (prevProp.modalVisible !== this.props.modalVisible)
      this.setState({ modalVisible: this.props.modalVisible });
    if (prevProp.id !== this.props.id && this.props.id > 0) {
      getTollById(this.props.id).then((toll) =>
        this.setState({ data: toll, inputDate: toll.date })
      );
    }
  }
  updateChanges() {
    updateToll(this.props.id, { date: this.state.inputDate })
      .then((ret) => {
        if (ret.success) {
          this.setState({ message: "Success - " + ret.message });
        } else {
          this.setState({ message: "Error - " + ret.message });
        }
      })
      .catch((e) =>
        this.setState({ message: "Error - " + e.message, fetchStatus: 1 })
      );
  }
  closeModal() {
    this.setState(
      {
        message: "",
        data: null,
        inputDate: "",
        modalVisible: false,
        fetchStatus: 0,
      },
      () => this.props.onClose()
    );
  }
  render() {
    return (
      <Modal
        visible={this.state.modalVisible}
        width="400"
        height="300"
        effect="fadeInUp"
        onClickAway={() => this.closeModal()}
      >
        <div className="editModal">
          <h3>Edit</h3>
          <div
            className={
              "message " + (this.state.fetchStatus > 0 ? "error" : null)
            }
          >
            {this.state.message}
          </div>
          <input
            value={this.state.inputDate}
            onChange={(e) => this.setState({ inputDate: e.target.value })}
          />
          <br />
          <button className="updateButton" onClick={() => this.updateChanges()}>
            Update
          </button>
        </div>
      </Modal>
    );
  }
}
