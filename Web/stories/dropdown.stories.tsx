import React from "react";
import { Dropdown, Gapped, MenuItem, Toast } from "@skbkontur/react-ui";
import { Meta } from "@storybook/react";

export default {
  title: "Dropdown",
} as Meta;

export const Default = () => {
  return (
    <Gapped>
      <Dropdown data-tid="DropdownId" caption="TODO">
        <MenuItem onClick={() => Toast.push("Clicked TODO 1")}>TODO 1</MenuItem>
        <MenuItem onClick={() => Toast.push("Clicked TODO 2")}>TODO 2</MenuItem>
      </Dropdown>
    </Gapped>
  );
};

export const Disabled = () => {
  return (
    <Gapped>
      <Dropdown data-tid="DropdownId" caption="TODO" disabled>
        <MenuItem onClick={() => Toast.push("Clicked TODO 1")}>TODO 1</MenuItem>
        <MenuItem onClick={() => Toast.push("Clicked TODO 2")}>TODO 2</MenuItem>
      </Dropdown>
    </Gapped>
  );
};

export const Error = () => {
  return (
    <Gapped>
      <Dropdown data-tid="DropdownId" caption="TODO" error>
        <MenuItem onClick={() => Toast.push("Clicked TODO 1")}>TODO 1</MenuItem>
        <MenuItem onClick={() => Toast.push("Clicked TODO 2")}>TODO 2</MenuItem>
      </Dropdown>
    </Gapped>
  );
};

export const Warning = () => {
  return (
    <Gapped>
      <Dropdown data-tid="DropdownId" caption="TODO" warning>
        <MenuItem onClick={() => Toast.push("Clicked TODO 1")}>TODO 1</MenuItem>
        <MenuItem onClick={() => Toast.push("Clicked TODO 2")}>TODO 2</MenuItem>
      </Dropdown>
    </Gapped>
  );
};
