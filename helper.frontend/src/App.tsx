import { useEffect, useState } from "react";
import classes from "./App.module.css";
import { AddUser } from "./components/AddUser/AddUser";
import { DataTable } from "./components/DataTable/DataTable";
import Button from "./components/UI/Button/Button";
import IUserDataModel from "./models/IUserDataModel";

export const App = () => {
  const [showAddUserComponent, setShowAddUserComponent] =
    useState<boolean>(false);

  const [userData, setUserData] = useState<IUserDataModel[]>([]);
  const [showAddButton, setShowAddButton] = useState(true);

  const handleAddUserComponent = () => {
    setShowAddUserComponent(!showAddUserComponent);
  };

  const handleShowEditUserComponent = () => {
    setShowAddUserComponent(false);
    setShowAddButton(false);
  };

  const handleHideEditUserComponent = () => {
    setShowAddButton(true);
  };

  useEffect(() => {
    fetch("https://localhost:44362/api/User")
      .then((response) => response.json())
      .then((json) => setUserData(json));
  }, [userData]);

  return (
    <div className={classes.placeHolder}>
      {!showAddUserComponent && showAddButton && (
        <Button onClick={handleAddUserComponent}>Add User</Button>
      )}
      {showAddUserComponent && (
        <AddUser ClickHandler={handleAddUserComponent} />
      )}
      <DataTable
        users={userData}
        showEditComponent={handleShowEditUserComponent}
        hideEditComponent={handleHideEditUserComponent}
      />
    </div>
  );
};
