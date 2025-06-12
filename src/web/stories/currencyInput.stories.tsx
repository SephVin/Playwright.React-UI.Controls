import type { Meta, StoryObj } from "@storybook/react";
import type { CurrencyInputProps } from "@skbkontur/react-ui";
import { Tooltip } from "@skbkontur/react-ui";
import { CurrencyInput, Gapped } from "@skbkontur/react-ui";
// eslint-disable-next-line
import React, { useEffect, useState } from "react";
import type { Nullable } from "@skbkontur/react-ui/typings/utility-types";

export enum CurrencyInputTestIds {
  CurrencyInputId = "CurrencyInputId",
}

const CurrencyInputTemplate = (props: CurrencyInputProps) => {
  const [value, setValue] = useState<Nullable<number>>(props.value);

  return (
    <Gapped>
      <CurrencyInput
        {...props}
        data-attribute-without-value={""}
        data-tid={CurrencyInputTestIds.CurrencyInputId}
        placeholder="PlaceholderText"
        value={value}
        onValueChange={setValue}
      />
    </Gapped>
  );
};

const meta: Meta<typeof CurrencyInputTemplate> = {
  title: "CurrencyInput",
  component: CurrencyInputTemplate,
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
    value: 9999.23,
  },
};

export const Hidden: Story = {
  render: () => {
    const [isVisible, setIsVisible] = useState(true);
    const [value, setValue] = useState<Nullable<number>>();

    useEffect(() => {
      const timer = setTimeout(() => {
        setIsVisible(false);
      }, 2000);

      return () => clearTimeout(timer);
    }, []);

    return (
      <Gapped>
        {isVisible && (
          <CurrencyInput
            data-tid={CurrencyInputTestIds.CurrencyInputId}
            onValueChange={setValue}
            value={value}
          />
        )}
      </Gapped>
    );
  },
};

export const WithTooltip: Story = {
  render: () => {
    const [value, setValue] = useState<Nullable<number>>();

    return (
      <Gapped>
        <Tooltip render={() => <div>TooltipText</div>}>
          <CurrencyInput
            data-tid={CurrencyInputTestIds.CurrencyInputId}
            onValueChange={setValue}
            value={value}
          />
        </Tooltip>
      </Gapped>
    );
  },
};
