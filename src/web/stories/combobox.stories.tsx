import React, { useState } from "react";
import { ComboBox, ComboBoxItem, Gapped } from "@skbkontur/react-ui";
import { Meta } from "@storybook/react";
import {
  getNumbers,
  getNumbersWithDelay,
  numbers,
} from "./Helpers/comboboxHelper";

export default {
  title: "Combobox",
} as Meta;

export const Default = () => {
  const [selectedNumber, selectNumber] = useState<ComboBoxItem>();

  return (
    <Gapped>
      <ComboBox
        data-tid="ComboboxId"
        getItems={getNumbers}
        onValueChange={selectNumber}
        value={selectedNumber}
      />
    </Gapped>
  );
};

export const Loading = () => {
  const [selectedNumber, selectNumber] = useState<ComboBoxItem>();

  return (
    <Gapped>
      <ComboBox
        data-tid="ComboboxId"
        getItems={getNumbersWithDelay}
        onValueChange={selectNumber}
        value={selectedNumber}
      />
    </Gapped>
  );
};

export const Disabled = () => (
  <Gapped>
    <Gapped>
      <ComboBox data-tid="ComboboxId" getItems={getNumbers} disabled></ComboBox>
    </Gapped>
  </Gapped>
);

export const Error = () => (
  <Gapped>
    <Gapped>
      <ComboBox data-tid="ComboboxId" getItems={getNumbers} error></ComboBox>
    </Gapped>
  </Gapped>
);

export const Warning = () => (
  <Gapped>
    <Gapped>
      <ComboBox data-tid="ComboboxId" getItems={getNumbers} warning></ComboBox>
    </Gapped>
  </Gapped>
);

export const Filled = () => {
  const [selectedNumber, selectNumber] = useState<ComboBoxItem>(numbers[0]);

  return (
    <Gapped>
      <ComboBox
        data-tid="ComboboxId"
        getItems={getNumbers}
        onValueChange={selectNumber}
        value={selectedNumber}
      />
    </Gapped>
  );
};
