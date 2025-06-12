import type { Meta, StoryObj } from "@storybook/react";
import type { ToggleProps } from "@skbkontur/react-ui";
import { Tooltip, Gapped, Toggle } from "@skbkontur/react-ui";
import React, { useEffect, useState } from "react";

export enum ToggleTestIds {
  ToggleId = "ToggleId",
  LabelId = "LabelId",
}

const ToggleTemplate = (props: ToggleProps) => {
  const [checked, setChecked] = useState(props.checked);

  return (
    <Gapped>
      <Toggle
        {...props}
        data-attribute-without-value={""}
        data-tid={ToggleTestIds.ToggleId}
        checked={checked}
        onValueChange={setChecked}
      >
        TODO
      </Toggle>
    </Gapped>
  );
};

const meta: Meta<typeof ToggleTemplate> = {
  title: "Toggle",
  component: ToggleTemplate,
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
    checked: true,
  },
};

export const WithTooltip: Story = {
  render: () => (
    <Gapped>
      <Tooltip render={() => <div>TooltipText</div>}>
        <Toggle data-tid={ToggleTestIds.ToggleId}>TODO</Toggle>
      </Tooltip>
    </Gapped>
  ),
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
        {isVisible && <Toggle data-tid={ToggleTestIds.ToggleId}>TODO</Toggle>}
      </Gapped>
    );
  },
};

export const FocusAndBlur: Story = {
  render: () => {
    const [isShowLabel, setShowLabel] = useState(false);

    return (
      <Gapped>
        <Toggle
          data-tid={ToggleTestIds.ToggleId}
          onFocus={() => setShowLabel(true)}
          onBlur={() => setShowLabel(false)}
        >
          TODO
        </Toggle>
        {isShowLabel && (
          <div data-tid={ToggleTestIds.LabelId}>Hello world!</div>
        )}
      </Gapped>
    );
  },
};
