import React from "react";
import classes from "./Card.module.css";

export const Card = (props: any) => {
  return (
    <div className={`${classes.card} ${props.className}`}>{props.children}</div>
  );
};
