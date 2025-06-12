import React, { useState } from "react";
import { Radio, Gapped, RadioGroup } from "@skbkontur/react-ui";
import { Meta } from "@storybook/react";

export default {
  title: "ControlList",
} as Meta;

export const Default = () => {
  const [chosen, setChosen] = useState(0);

  return (
    <Gapped>
      <RadioGroup
        data-tid="RadioGroupId"
        value={chosen}
        onValueChange={(value) => setChosen(value)}
      >
        <Gapped gap={3} vertical>
          <Radio value={1}>TODO 1</Radio>
          <Radio value={2}>TODO 2</Radio>
          <Radio value={3}>TODO 3</Radio>
        </Gapped>
      </RadioGroup>
    </Gapped>
  );
};

export const SingleElement = () => {
  const [chosen, setChosen] = useState(0);

  return (
    <Gapped>
      <RadioGroup
        data-tid="RadioGroupId"
        value={chosen}
        onValueChange={(value) => setChosen(value)}
      >
        <Gapped gap={3} vertical>
          <Radio value={1}>TODO 1</Radio>
        </Gapped>
      </RadioGroup>
    </Gapped>
  );
};
