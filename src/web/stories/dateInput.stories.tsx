import {
  DateInput,
  DateInputProps,
  DatePicker,
  Gapped,
  Tooltip,
} from "@skbkontur/react-ui";
import React, { useEffect, useState } from "react";
import type { Meta, StoryObj } from "@storybook/react";

export enum DateInputTestIds {
  DateInputId = "DateInputId",
}

const DateInputTemplate = (props: DateInputProps) => {
  const [value, setValue] = useState(props.value);

  return (
    <Gapped>
      <DateInput
        {...props}
        data-attribute-without-value={""}
        data-tid={DateInputTestIds.DateInputId}
        value={value}
        onValueChange={setValue}
      />
    </Gapped>
  );
};

const meta: Meta<typeof DateInputTemplate> = {
  title: "DateInput",
  component: DateInputTemplate,
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

export const Filled: Story = {
  args: {
    ...Default.args,
    value: "01.01.2024",
  },
};

export const Hidden: Story = {
  render: () => {
    const [value, setValue] = useState("");
    const [isVisible, setIsVisible] = useState(true);

    useEffect(() => {
      const timer = setTimeout(() => {
        setIsVisible(false);
      }, 2000);

      return () => clearTimeout(timer);
    }, []);

    return (
      <Gapped>
        {isVisible && (
          <DatePicker
            data-tid={DateInputTestIds.DateInputId}
            value={value}
            onValueChange={setValue}
          />
        )}
      </Gapped>
    );
  },
};

export const WithTooltip: Story = {
  render: () => {
    const [value, setValue] = useState("");

    return (
      <Gapped>
        <Tooltip render={() => <div>TooltipText</div>}>
          <DatePicker
            data-tid={DateInputTestIds.DateInputId}
            value={value}
            onValueChange={setValue}
          />
        </Tooltip>
      </Gapped>
    );
  },
};
