import React, { useState } from "react";
import { Gapped, Textarea } from "@skbkontur/react-ui";
import { Meta } from "@storybook/react";

export default {
  title: "Textarea",
} as Meta;

export const Default = () => {
  const [value, setValue] = useState("");

  return (
    <Gapped>
      <Textarea
        data-tid="TextareaId"
        value={value}
        onValueChange={setValue}
        autoResize
        placeholder="Placeholder"
      />
    </Gapped>
  );
};

export const Disabled = () => {
  const [value, setValue] = useState("");

  return (
    <Gapped>
      <Textarea
        data-tid="TextareaId"
        value={value}
        onValueChange={setValue}
        autoResize
        placeholder="Placeholder"
        disabled
      />
    </Gapped>
  );
};

export const Error = () => {
  const [value, setValue] = useState("");

  return (
    <Gapped>
      <Textarea
        data-tid="TextareaId"
        value={value}
        onValueChange={setValue}
        autoResize
        placeholder="Placeholder"
        error
      />
    </Gapped>
  );
};

export const Warning = () => {
  const [value, setValue] = useState("");

  return (
    <Gapped>
      <Textarea
        data-tid="TextareaId"
        value={value}
        onValueChange={setValue}
        autoResize
        placeholder="Placeholder"
        warning
      />
    </Gapped>
  );
};

export const Filled = () => {
  const [value, setValue] = useState("TODO");

  return (
    <Gapped>
      <Textarea
        data-tid="TextareaId"
        value={value}
        onValueChange={setValue}
        autoResize
        placeholder="Placeholder"
      />
    </Gapped>
  );
};
