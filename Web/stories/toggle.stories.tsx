import React, { useState } from "react";
import { Gapped, Toggle } from "@skbkontur/react-ui";
import { Meta } from "@storybook/react";

export default {
  title: "Toggle",
} as Meta;

export const Default = () => {
  const [checked, setChecked] = useState(false);

  return (
    <Gapped>
      <Toggle data-tid="ToggleId" checked={checked} onValueChange={setChecked}>
        TODO
      </Toggle>
    </Gapped>
  );
};

export const Disabled = () => {
  const [checked, setChecked] = useState(false);

  return (
    <Gapped>
      <Toggle
        data-tid="ToggleId"
        checked={checked}
        onValueChange={setChecked}
        disabled
      >
        TODO
      </Toggle>
    </Gapped>
  );
};

export const Loading = () => {
  const [checked, setChecked] = useState(false);

  return (
    <Gapped>
      <Toggle
        data-tid="ToggleId"
        checked={checked}
        onValueChange={setChecked}
        loading
      >
        TODO
      </Toggle>
    </Gapped>
  );
};

export const Error = () => {
  const [checked, setChecked] = useState(false);

  return (
    <Gapped>
      <Toggle
        data-tid="ToggleId"
        checked={checked}
        onValueChange={setChecked}
        error
      >
        TODO
      </Toggle>
    </Gapped>
  );
};

export const Warning = () => {
  const [checked, setChecked] = useState(false);

  return (
    <Gapped>
      <Toggle
        data-tid="ToggleId"
        checked={checked}
        onValueChange={setChecked}
        warning
      >
        TODO
      </Toggle>
    </Gapped>
  );
};

export const Checked = () => {
  return (
    <Gapped>
      <Toggle data-tid="ToggleId" defaultChecked>
        TODO
      </Toggle>
    </Gapped>
  );
};
