import IUserDataModel from "../../models/IUserDataModel";
import Button from "../UI/Button/Button";
import classes from "./EditUser.module.css";
import { EditUserForm } from "./EditUserForm/EditUserForm";

interface ToggleEditPanel {
  ClickHandler: (user: IUserDataModel) => void;
  hideEdit: () => void;
  user: IUserDataModel;
}

export const EditUser = (props: ToggleEditPanel) => {
  const onEditUserHandler = (user: IUserDataModel) => {
    fetch("https://localhost:44362/api/User", {
      mode: "cors",
      method: "PUT",
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

  return (
    <>
      <div className={classes.content}>
        <div>EditUser</div>
        <div>
          <EditUserForm
            userData={props.user}
            onEditUserHandler={onEditUserHandler}
          />
        </div>
        <div>
          <Button onClick={props.hideEdit}>Hide Edit Panel</Button>
        </div>
      </div>
    </>
  );
};
