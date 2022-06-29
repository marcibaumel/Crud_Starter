import React, { useEffect, useState } from "react";
import IUserDataModel from "../../../models/IUserDataModel";
import Button from "../../UI/Button/Button";
import classes from "./UserRow.module.css";

interface IUserRowType {
  id: number;
  username: string;
  email: string;
  gender: string;
  toggleEditUserComponent: (user: IUserDataModel) => void;
  deleteUser: (id: number) => void;
}

export const UserRow = (props: IUserRowType) => {
  const [data, setData] = useState<IUserDataModel>({
    id: 0,
    username: "",
    email: "",
    gender: "",
  });

  useEffect(() => {
    setData(props);

    return () => {
      //console.log("Updated user props");
    };
  }, [props]);

  const handleUserClick = () => {
    props.toggleEditUserComponent(data);
  };

  return (
    <tr>
      <td>{data.username}</td>
      <td>{data.email}</td>
      <td>{data.gender}</td>
      <td>
        <Button className={classes.editButton} onClick={handleUserClick}>
          Edit
        </Button>
        <Button
          className={classes.deleteButton}
          onClick={() => props.deleteUser(data.id)}
        >
          Delete
        </Button>
      </td>
    </tr>
  );
};
