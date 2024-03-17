import React, { useState } from "react";
import { FxInput, Gapped } from "@skbkontur/react-ui";
import { Meta } from "@storybook/react";

export default {
  title: "FxInput",
} as Meta;

export const Default = () => {
  const [auto, setAuto] = useState(false);
  const [value, setValue] = useState("");

  function handleValueChange(value: any) {
    setAuto(false);
    setValue(value);
  }

  function handleRestore() {
    setAuto(true);
    setValue("auto");
  }

  return (
    <Gapped>
      <FxInput
        data-tid="FxInputId"
        auto={auto}
        value={value}
        onValueChange={handleValueChange}
        onRestore={handleRestore}
      />
    </Gapped>
  );
};

export const Disabled = () => {
  const [auto, setAuto] = useState(false);
  const [value, setValue] = useState("");

  function handleValueChange(value: any) {
    setAuto(false);
    setValue(value);
  }

  function handleRestore() {
    setAuto(true);
    setValue("auto");
  }

  return (
    <Gapped>
      <FxInput
        data-tid="FxInputId"
        auto={auto}
        value={value}
        onValueChange={handleValueChange}
        onRestore={handleRestore}
        disabled
      />
    </Gapped>
  );
};

export const Error = () => {
  const [auto, setAuto] = useState(false);
  const [value, setValue] = useState("");

  function handleValueChange(value: any) {
    setAuto(false);
    setValue(value);
  }

  function handleRestore() {
    setAuto(true);
    setValue("auto");
  }

  return (
    <Gapped>
      <FxInput
        data-tid="FxInputId"
        auto={auto}
        value={value}
        onValueChange={handleValueChange}
        onRestore={handleRestore}
        error
      />
    </Gapped>
  );
};

export const Warning = () => {
  const [auto, setAuto] = useState(false);
  const [value, setValue] = useState("");

  function handleValueChange(value: any) {
    setAuto(false);
    setValue(value);
  }

  function handleRestore() {
    setAuto(true);
    setValue("auto");
  }

  return (
    <Gapped>
      <FxInput
        data-tid="FxInputId"
        auto={auto}
        value={value}
        onValueChange={handleValueChange}
        onRestore={handleRestore}
        warning
      />
    </Gapped>
  );
};

export const Filled = () => {
  const [auto, setAuto] = useState(false);
  const [value, setValue] = useState("TODO");

  function handleValueChange(value: any) {
    setAuto(false);
    setValue(value);
  }

  function handleRestore() {
    setAuto(true);
    setValue("auto");
  }

  return (
    <Gapped>
      <FxInput
        data-tid="FxInputId"
        auto={auto}
        value={value}
        onValueChange={handleValueChange}
        onRestore={handleRestore}
      />
    </Gapped>
  );
};

export const Auto = () => {
  const [value, setValue] = useState("TODO");

  function handleValueChange(value: any) {
    setValue(value);
  }

  function handleRestore() {
    setValue("auto");
  }

  return (
    <Gapped>
      <FxInput
        data-tid="FxInputId"
        auto={true}
        value={value}
        onValueChange={handleValueChange}
        onRestore={handleRestore}
      />
    </Gapped>
  );
};
