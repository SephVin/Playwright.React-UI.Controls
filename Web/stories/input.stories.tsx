import React, { useState } from "react";
import { Input, Gapped } from "@skbkontur/react-ui";
import { Meta } from "@storybook/react";

export default {
  title: "Input",
} as Meta;

export const Default = () => {
  const [value, setValue] = useState("");

  return (
    <Gapped>
      <Input data-tid="InputId" value={value} onValueChange={setValue} />
    </Gapped>
  );
};

export const Disabled = () => (
  <Gapped>
    <Input data-tid="InputId" disabled />
  </Gapped>
);

export const Error = () => (
  <Gapped>
    <Input data-tid="InputId" error />
  </Gapped>
);

export const Warning = () => (
  <Gapped>
    <Input data-tid="InputId" warning />
  </Gapped>
);

export const Filled = () => {
  const [value, setValue] = useState("TODO");

  return (
    <Gapped>
      <Input data-tid="InputId" value={value} onValueChange={setValue} />
    </Gapped>
  );
};

export const TimeMask = () => {
  const [value, setValue] = useState("");

  return (
    <Gapped>
      <Input
        data-tid="InputId"
        value={value}
        mask="99:99"
        placeholder="00:00"
        onValueChange={setValue}
      />
    </Gapped>
  );
};

export const TimeType = () => {
  const [value, setValue] = useState("");

  return (
    <Gapped>
      <Input
        data-tid="InputId"
        value={value}
        type="time"
        onValueChange={setValue}
      />
    </Gapped>
  );
};

export const DateType = () => {
  const [value, setValue] = useState("");

  return (
    <Gapped>
      <Input
        data-tid="InputId"
        value={value}
        type="date"
        onValueChange={setValue}
      />
    </Gapped>
  );
};

export const NumberType = () => {
  const [value, setValue] = useState("");

  return (
    <Gapped>
      <Input
        data-tid="InputId"
        value={value}
        type="number"
        onValueChange={setValue}
      />
    </Gapped>
  );
};
