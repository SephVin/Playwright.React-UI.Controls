import type { Meta, StoryObj } from "@storybook/react";
import { Gapped, Input, Tooltip } from "@skbkontur/react-ui";
import React, { useEffect, useState } from "react";

export enum InputTestIds {
  InputId = "InputId",
}

const meta: Meta<typeof Input> = {
  title: "Input",
  component: Input,
};
export default meta;

type Story = StoryObj<typeof meta>;

export const Default: Story = {
  render(args) {
    const [value, setValue] = useState(args.value);

    return (
      <Gapped>
        <Input
          {...args}
          data-attribute-without-value={""}
          data-tid={InputTestIds.InputId}
          value={value}
          onValueChange={setValue}
          placeholder="PlaceholderText"
        >
          TODO
        </Input>
      </Gapped>
    );
  },
};

export const Disabled: Story = {
  ...Default,
  args: {
    disabled: true,
  },
};

export const Error: Story = {
  ...Default,
  args: {
    error: true,
  },
};

export const Warning: Story = {
  ...Default,
  args: {
    warning: true,
  },
};

export const Filled: Story = {
  ...Default,
  args: {
    value: "TODO",
  },
};

export const Hidden: Story = {
  render: () => {
    const [isVisible, setIsVisible] = useState(true);

    useEffect(() => {
      const timer = setTimeout(() => {
        setIsVisible(false);
      }, 2000);

      return () => clearTimeout(timer);
    }, []);

    return (
      <Gapped>
        {isVisible && <Input data-tid={InputTestIds.InputId}>TODO</Input>}
      </Gapped>
    );
  },
};

export const WithTooltip: Story = {
  render: () => (
    <Gapped>
      <Tooltip render={() => <div>TooltipText</div>}>
        <Input data-tid={InputTestIds.InputId}>TODO</Input>
      </Tooltip>
    </Gapped>
  ),
};
