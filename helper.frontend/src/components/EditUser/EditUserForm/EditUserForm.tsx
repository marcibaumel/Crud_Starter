import React, { useEffect, useState } from "react";
import IUserDataModel from "../../../models/IUserDataModel";
import Button from "../../UI/Button/Button";
import { Card } from "../../UI/Card/Card";
import classes from "./EditUserForm.module.css";
import {
  InputChangeEventHandler,
  SelectChangeEventHandler,
} from "../../../models/InputTypes";

interface userDataProps {
  userData: IUserDataModel;
  onEditUserHandler: (user: IUserDataModel) => void;
}

export const EditUserForm = (props: userDataProps) => {
  const [username, setUsername] = useState("");
  const [email, setEmail] = useState("");
  const [usernameError, setUsernameError] = useState(false);
  const [emailError, setEmailError] = useState(false);
  const [gender, setGender] = useState("");

  useEffect(() => {
    setUsername(props.userData.username);
    setEmail(props.userData.email);
    setGender(props.userData.gender);
  }, [props.userData.username, props.userData.email, props.userData.gender]);

  const usernameChangeHandler: InputChangeEventHandler = (event) => {
    setUsername(event.target.value);
    //console.log(event.target.value);
  };

  const emailChangeHandler: InputChangeEventHandler = (event) => {
    setEmail(event.target.value);
    //console.log(event.target.value);
  };

  const genderChangeHandler: SelectChangeEventHandler = (event) => {
    setGender(event.target.value);
    //console.log(event.target.value);
  };

  const onEditUserEvent = (event: React.SyntheticEvent) => {
    event.preventDefault();

    if (username.length < 3 && username.length > 15) {
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
      id: props.userData.id,
      username: username,
      email: email,
      gender: gender,
    };
    props.onEditUserHandler(user);
  };

  return (
    <>
      <Card className={classes.input}>
        <form onSubmit={onEditUserEvent}>
          <label htmlFor="username">Username</label>
          <input
            id="username"
            type="text"
            onChange={usernameChangeHandler}
            value={username}
          />
          {usernameError && (
            <p className={classes.ErrorParagraph}>Username format error</p>
          )}
          <label htmlFor="email">Email</label>
          <input
            id="email"
            onChange={emailChangeHandler}
            value={email}
            type="email"
          />
          {emailError && (
            <p className={classes.ErrorParagraph}>Email format error</p>
          )}

          <label htmlFor="gender">Gender</label>
          <select onChange={genderChangeHandler}>
            <option selected={gender === "Male"} value="Male">
              Male
            </option>
            <option selected={gender === "Female"} value="Female">
              Female
            </option>
            <option selected={gender === "Other"} value="Other">
              Other
            </option>
          </select>

          <Button className={classes.editButton} type="submit">
            Edit User
          </Button>
        </form>
      </Card>
    </>
  );
};
