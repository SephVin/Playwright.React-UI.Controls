import React, { useState } from "react";
import { Radio, Gapped, RadioGroup } from "@skbkontur/react-ui";
import { Meta } from "@storybook/react";

export default {
  title: "RadioGroup",
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
        </Gapped>
      </RadioGroup>
    </Gapped>
  );
};

export const Disabled = () => {
  const [chosen, setChosen] = useState(0);

  return (
    <Gapped>
      <RadioGroup
        data-tid="RadioGroupId"
        disabled
        value={chosen}
        onValueChange={(value) => setChosen(value)}
      >
        <Gapped gap={3} vertical>
          <Radio value={1}>TODO 1</Radio>
          <Radio value={2}>TODO 2</Radio>
        </Gapped>
      </RadioGroup>
    </Gapped>
  );
};

export const DisabledItem = () => {
  const [chosen, setChosen] = useState(0);

  return (
    <Gapped>
      <RadioGroup
        data-tid="RadioGroupId"
        value={chosen}
        onValueChange={(value) => setChosen(value)}
      >
        <Gapped gap={3} vertical>
          <Radio value={1} disabled>
            TODO 1
          </Radio>
          <Radio value={2}>TODO 2</Radio>
        </Gapped>
      </RadioGroup>
    </Gapped>
  );
};
export const Error = () => {
  const [chosen, setChosen] = useState(0);

  return (
    <Gapped>
      <RadioGroup
        data-tid="RadioGroupId"
        error
        value={chosen}
        onValueChange={(value) => setChosen(value)}
      >
        <Gapped gap={3} vertical>
          <Radio value={1}>TODO 1</Radio>
          <Radio value={2}>TODO 2</Radio>
        </Gapped>
      </RadioGroup>
    </Gapped>
  );
};

export const ErrorItem = () => {
  const [chosen, setChosen] = useState(0);

  return (
    <Gapped>
      <RadioGroup
        data-tid="RadioGroupId"
        value={chosen}
        onValueChange={(value) => setChosen(value)}
      >
        <Gapped gap={3} vertical>
          <Radio value={1} error>
            TODO 1
          </Radio>
          <Radio value={2}>TODO 2</Radio>
        </Gapped>
      </RadioGroup>
    </Gapped>
  );
};
export const Warning = () => {
  const [chosen, setChosen] = useState(0);

  return (
    <Gapped>
      <RadioGroup
        data-tid="RadioGroupId"
        warning
        value={chosen}
        onValueChange={(value) => setChosen(value)}
      >
        <Gapped gap={3} vertical>
          <Radio value={1}>TODO 1</Radio>
          <Radio value={2}>TODO 2</Radio>
        </Gapped>
      </RadioGroup>
    </Gapped>
  );
};

export const WarningItem = () => {
  const [chosen, setChosen] = useState(0);

  return (
    <Gapped>
      <RadioGroup
        data-tid="RadioGroupId"
        value={chosen}
        onValueChange={(value) => setChosen(value)}
      >
        <Gapped gap={3} vertical>
          <Radio value={1} warning>
            TODO 1
          </Radio>
          <Radio value={2}>TODO 2</Radio>
        </Gapped>
      </RadioGroup>
    </Gapped>
  );
};

export const Checked = () => {
  const [chosen, setChosen] = useState(2);

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
        </Gapped>
      </RadioGroup>
    </Gapped>
  );
};
