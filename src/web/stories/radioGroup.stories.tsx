import type { Meta, StoryObj } from "@storybook/react";
import type { RadioGroupProps } from "@skbkontur/react-ui";
import { Tooltip } from "@skbkontur/react-ui";
import { Gapped, Radio, RadioGroup } from "@skbkontur/react-ui";
// eslint-disable-next-line
import React, { useEffect, useState } from "react";

export enum RadioGroupTestIds {
  RadioGroupId = "RadioGroupId",
}

type TemplateProps = Omit<RadioGroupProps<number>, "onValueChange">;

const RadioGroupTemplate: React.FC<TemplateProps> = (props) => {
  const [chosen, setChosen] = useState(0);

  return (
    <Gapped>
      <RadioGroup
        data-attribute-without-value={""}
        data-tid={RadioGroupTestIds.RadioGroupId}
        value={chosen}
        onValueChange={(value) => setChosen(value)}
        {...props}
      >
        <Gapped gap={3} vertical>
          <Radio value={1}>TODO 1</Radio>
          <Radio value={2}>TODO 2</Radio>
        </Gapped>
      </RadioGroup>
    </Gapped>
  );
};

const meta: Meta<typeof RadioGroupTemplate> = {
  title: "RadioGroup",
  component: RadioGroupTemplate,
};
export default meta;

type Story = StoryObj<typeof meta>;

export const Default: Story = {};

export const Disabled: Story = {
  args: {
    ...Default.args,
    disabled: true,
  },
};

export const Error: Story = {
  args: {
    ...Default.args,
    error: true,
  },
};

export const Warning: Story = {
  args: {
    ...Default.args,
    warning: true,
  },
};

export const Checked: Story = {
  args: {
    ...Default.args,
    value: 2,
  },
};

export const DisabledItem: Story = {
  render: () => {
    const [chosen, setChosen] = useState(0);

    return (
      <Gapped>
        <RadioGroup
          data-tid={RadioGroupTestIds.RadioGroupId}
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
  },
};

export const ErrorItem: Story = {
  render: () => {
    const [chosen, setChosen] = useState(0);

    return (
      <Gapped>
        <RadioGroup
          data-tid={RadioGroupTestIds.RadioGroupId}
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
  },
};

export const WarningItem: Story = {
  render: () => {
    const [chosen, setChosen] = useState(0);

    return (
      <Gapped>
        <RadioGroup
          data-tid={RadioGroupTestIds.RadioGroupId}
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
  },
};

export const Hidden: Story = {
  render: () => {
    const [isVisible, setIsVisible] = useState(true);
    const [chosen, setChosen] = useState(0);

    useEffect(() => {
      const timer = setTimeout(() => {
        setIsVisible(false);
      }, 2000);

      return () => clearTimeout(timer);
    }, []);

    return (
      <Gapped>
        {isVisible && (
          <RadioGroup
            data-tid={RadioGroupTestIds.RadioGroupId}
            value={chosen}
            onValueChange={(value) => setChosen(value)}
          >
            <Gapped gap={3} vertical>
              <Radio value={1}>TODO 1</Radio>
              <Radio value={2}>TODO 2</Radio>
            </Gapped>
          </RadioGroup>
        )}
      </Gapped>
    );
  },
};

export const WithTooltip: Story = {
  render: () => {
    const [chosen, setChosen] = useState(0);

    return (
      <Gapped>
        <Tooltip render={() => <div>TooltipText</div>}>
          <RadioGroup
            data-tid={RadioGroupTestIds.RadioGroupId}
            value={chosen}
            onValueChange={(value) => setChosen(value)}
          >
            <Gapped gap={3} vertical>
              <Radio value={1}>TODO 1</Radio>
              <Radio value={2}>TODO 2</Radio>
            </Gapped>
          </RadioGroup>
        </Tooltip>
      </Gapped>
    );
  },
};
