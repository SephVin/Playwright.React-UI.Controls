import React from "react";
import { Gapped, Kebab, MenuItem, Toast } from "@skbkontur/react-ui";
import { Meta } from "@storybook/react";
import { style } from "./utils/kebabHelper";

export default {
  title: "Kebab",
} as Meta;

export const Default = () => {
  let Card = () => (
    <div style={style}>
      <div>
        <h3>TODO</h3>
      </div>

      <Kebab data-tid="KebabId" size={"small"}>
        <MenuItem onClick={() => Toast.push("Clicked TODO 1")}>TODO 1</MenuItem>
        <MenuItem onClick={() => Toast.push("Clicked TODO 2")}>TODO 2</MenuItem>
      </Kebab>
    </div>
  );

  return (
    <Gapped>
      <Card />
    </Gapped>
  );
};

export const Disabled = () => {
  let Card = () => (
    <div style={style}>
      <div>
        <h3>TODO</h3>
      </div>

      <Kebab data-tid="KebabId" size={"small"} disabled>
        <MenuItem onClick={() => Toast.push("Clicked TODO 1")}>TODO 1</MenuItem>
        <MenuItem onClick={() => Toast.push("Clicked TODO 2")}>TODO 2</MenuItem>
      </Kebab>
    </div>
  );

  return (
    <Gapped>
      <Card />
    </Gapped>
  );
};
