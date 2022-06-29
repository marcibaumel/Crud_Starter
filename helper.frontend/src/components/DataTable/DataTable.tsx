import React, { useState } from "react";
import IUserDataModel from "../../models/IUserDataModel";
import { EditUser } from "../EditUser/EditUser";
import classes from "./DataTable.module.css";
import { UserRow } from "./UserRow/UserRow";

interface DataTablePropsType {
  users: IUserDataModel[];
  showEditComponent: () => void;
  hideEditComponent: () => void;
}

export const DataTable = (props: DataTablePropsType) => {
  const [showEditUserComponent, setShowEditUserComponent] =
    useState<boolean>(false);

  const [user, setUser] = useState<IUserDataModel>({
    id: 0,
    username: "",
    email: "",
    gender: "",
  });

  const handleEditUserComponent = (data: IUserDataModel) => {
    setUser(data);
    props.showEditComponent();
    setShowEditUserComponent(true);
  };

  const closeEditUserComponent = () => {
    setShowEditUserComponent(false)
    props.hideEditComponent();
  }

  const deleteUserHandler = (id: number) => {
    fetch(`https://localhost:44362/api/User/${id}`, {
      mode: "cors",
      method: "DELETE",
      headers: { "Content-Type": "application/json" },
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

  return (
    <>
      <div>
        {showEditUserComponent && (
          <EditUser hideEdit={closeEditUserComponent} ClickHandler={handleEditUserComponent} user={user} />
        )}
        <div>
          <table className={classes.table}>
            <tbody>
              <tr>
                <th>Name</th>
                <th>Email</th>
                <th>Gender</th>
                <th>Action</th>
              </tr>
              {props.users.map((e) => (
                <UserRow
                  key={e.id}
                  id={e.id}
                  username={e.username}
                  email={e.email}
                  gender={e.gender}
                  toggleEditUserComponent={handleEditUserComponent}
                  deleteUser={deleteUserHandler}
                />
              ))}
            </tbody>
          </table>
        </div>
      </div>
    </>
  );
};
