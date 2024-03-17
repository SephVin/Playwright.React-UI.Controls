import React, { useState } from "react";
import { Checkbox, Gapped } from "@skbkontur/react-ui";
import { Meta } from "@storybook/react";

export default {
  title: "Checkbox",
} as Meta;

export const Default = () => {
  const [checked, setChecked] = useState(false);

  return (
    <Gapped>
      <Checkbox
        data-tid="CheckboxId"
        checked={checked}
        onValueChange={setChecked}
      >
        TODO
      </Checkbox>
    </Gapped>
  );
};

export const Disabled = () => (
  <Gapped>
    <Checkbox data-tid="CheckboxId" disabled>
      TODO
    </Checkbox>
  </Gapped>
);

export const Checked = () => {
  const [checked, setChecked] = useState(true);

  return (
    <Gapped>
      <Checkbox
        data-tid="CheckboxId"
        checked={checked}
        onValueChange={setChecked}
      >
        TODO
      </Checkbox>
    </Gapped>
  );
};

export const Error = () => (
  <Gapped>
    <Checkbox data-tid="CheckboxId" error>
      TODO
    </Checkbox>
  </Gapped>
);

export const Warning = () => (
  <Gapped>
    <Checkbox data-tid="CheckboxId" warning>
      TODO
    </Checkbox>
  </Gapped>
);

export const InitialIndeterminate = () => (
  <Gapped>
    <Checkbox data-tid="CheckboxId" initialIndeterminate>
      TODO
    </Checkbox>
  </Gapped>
);
