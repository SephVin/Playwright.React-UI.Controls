import React, { useState } from "react";
import { CurrencyInput, Gapped } from "@skbkontur/react-ui";
import { Meta } from "@storybook/react";
import { Nullable } from "@skbkontur/react-ui/typings/utility-types";

export default {
  title: "CurrencyInput",
} as Meta;

export const Default = () => {
  const [value, setValue] = useState<Nullable<number>>();

  return (
    <Gapped>
      <CurrencyInput
        data-tid="CurrencyInputId"
        value={value}
        fractionDigits={3}
        onValueChange={setValue}
      />
    </Gapped>
  );
};

export const Disabled = () => {
  const [value, setValue] = useState<Nullable<number>>();

  return (
    <Gapped>
      <CurrencyInput
        data-tid="CurrencyInputId"
        value={value}
        fractionDigits={3}
        onValueChange={setValue}
        disabled
      />
    </Gapped>
  );
};

export const Error = () => {
  const [value, setValue] = useState<Nullable<number>>();

  return (
    <Gapped>
      <CurrencyInput
        data-tid="CurrencyInputId"
        value={value}
        fractionDigits={3}
        onValueChange={setValue}
        error
      />
    </Gapped>
  );
};

export const Warning = () => {
  const [value, setValue] = useState<Nullable<number>>();

  return (
    <Gapped>
      <CurrencyInput
        data-tid="CurrencyInputId"
        value={value}
        fractionDigits={3}
        onValueChange={setValue}
        warning
      />
    </Gapped>
  );
};

export const Filled = () => {
  const [value, setValue] = useState<Nullable<number>>(123.456);

  return (
    <Gapped>
      <CurrencyInput
        data-tid="CurrencyInputId"
        fractionDigits={3}
        value={value}
        onValueChange={setValue}
      />
    </Gapped>
  );
};
