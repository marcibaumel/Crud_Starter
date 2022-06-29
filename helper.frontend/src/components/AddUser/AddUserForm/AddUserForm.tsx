import React, { useState } from "react";
import IUserDataModel from "../../../models/IUserDataModel";
import Button from "../../UI/Button/Button";
import { Card } from "../../UI/Card/Card";
import classes from "./AddUserForm.module.css";
import {
  InputChangeEventHandler,
  SelectChangeEventHandler,
} from "../../../models/InputTypes";

interface UserHandler {
  onAddUser: (user: IUserDataModel) => void;
}

export const AddUserForm = (props: UserHandler) => {
  const [username, setUsername] = useState("");
  const [usernameError, setUsernameError] = useState(false);
  const [email, setEmail] = useState("");
  const [emailError, setEmailError] = useState(false);
  const [gender, setGender] = useState("Male");

  const usernameChangeHandler: InputChangeEventHandler = (event) => {
    setUsername(event.target.value);
  };

  const emailChangeHandler: InputChangeEventHandler = (event) => {
    setEmail(event.target.value);
  };

  const genderChangeHandler: SelectChangeEventHandler = (event) => {
    setGender(event.target.value);
  };

  const onAddUserEvent = (event: React.SyntheticEvent) => {
    event.preventDefault();

    if (username.length < 3 || username.length > 15) {
      setUsernameError(true);
      return;
    } else {
      setUsernameError(false);
    }

    if (
      !email.match(/^[\w-\.]+@([\w-]+\.)+[\w-]{2,4}$/i) ||
      email.length < 5 ||
      email.length > 50
    ) {
      setEmailError(true);
      return;
    } else {
      setEmailError(false);
    }

    let user: IUserDataModel = {
      id: 0,
      username: username,
      email: email,
      gender: gender,
    };

    props.onAddUser(user);
    setUsername("");
    setEmail("");
    setGender("Male");
  };

  return (
    <>
      <Card className={classes.input}>
        <form onSubmit={onAddUserEvent}>
          <label htmlFor="username">Username</label>
          <input
            onChange={usernameChangeHandler}
            id="username"
            type="text"
            value={username}
          />
          {usernameError && (
            <p className={classes.ErrorParagraph}>Username format error</p>
          )}

          <label htmlFor="email">Email</label>
          <input
            onChange={emailChangeHandler}
            id="email"
            type="email"
            value={email}
          />
          {emailError && (
            <p className={classes.ErrorParagraph}>Email format error</p>
          )}

          <label htmlFor="gender">Gender</label>

          <select onChange={genderChangeHandler} value={gender}>
            <option value="Male">Male</option>
            <option value="Female">Female</option>
            <option value="Other">Other</option>
          </select>

          <Button className={classes.addButton} type="submit">
            Add User
          </Button>
        </form>
      </Card>
    </>
  );
};
