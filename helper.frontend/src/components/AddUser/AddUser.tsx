import React from "react";
import IUserDataModel from "../../models/IUserDataModel";
import Button from "../UI/Button/Button";
import classes from "./AddUser.module.css";
import { AddUserForm } from "./AddUserForm/AddUserForm";

interface ToggleAddPanel {
  ClickHandler: () => void;
}

export const AddUser = (props: ToggleAddPanel) => {
  const addUserHandler = (user: IUserDataModel) => {
    fetch("https://localhost:44362/api/User", {
      mode: "cors",
      method: "POST",
      headers: { "Content-Type": "application/json" },
      body: JSON.stringify(user),
    })
      .then((res) => {
        if (res.status === 200) {
        } else {
          alert("Something went wrong");
        }
      })
      .catch(function (error) {
        console.log(error);
      });
  };

  const hideAddComponent = () => {
    props.ClickHandler();
  };

  return (
    <>
      <div className={classes.content}>
        <div>AddUser</div>
        <div>
          <AddUserForm onAddUser={addUserHandler} />
        </div>
        <div>
          <Button onClick={hideAddComponent}>Hide Add Panel</Button>
        </div>
      </div>
    </>
  );
};
