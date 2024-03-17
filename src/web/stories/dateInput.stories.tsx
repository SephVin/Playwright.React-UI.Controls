import React, { useState } from "react";
import { DateInput, Gapped } from "@skbkontur/react-ui";
import { Meta } from "@storybook/react";

export default {
  title: "DateInput",
} as Meta;

export const Default = () => {
  const [value, setValue] = useState("");

  return (
    <Gapped>
      <DateInput
        data-tid="DateInputId"
        value={value}
        onValueChange={setValue}
      />
    </Gapped>
  );
};

export const Disabled = () => {
  const [value, setValue] = useState("");

  return (
    <Gapped>
      <DateInput
        data-tid="DateInputId"
        value={value}
        onValueChange={setValue}
        disabled
      />
    </Gapped>
  );
};

export const Error = () => {
  const [value, setValue] = useState("");

  return (
    <Gapped>
      <DateInput
        data-tid="DateInputId"
        value={value}
        onValueChange={setValue}
        error
      />
    </Gapped>
  );
};

export const Warning = () => {
  const [value, setValue] = useState("");

  return (
    <Gapped>
      <DateInput
        data-tid="DateInputId"
        value={value}
        onValueChange={setValue}
        warning
      />
    </Gapped>
  );
};

export const Filled = () => {
  const [value, setValue] = useState("24.08.2022");

  return (
    <Gapped>
      <DateInput
        data-tid="DateInputId"
        value={value}
        onValueChange={setValue}
      />
    </Gapped>
  );
};
