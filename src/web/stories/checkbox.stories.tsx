import type { Meta, StoryObj } from "@storybook/react";
import { Checkbox, Gapped, Tooltip } from "@skbkontur/react-ui";
import React, { useEffect, useState } from "react";

export enum CheckboxTestIds {
  CheckboxId = "CheckboxId",
  LabelId = "LabelId",
}

const meta: Meta<typeof Checkbox> = {
  title: "Checkbox",
  component: Checkbox,
};
export default meta;

type Story = StoryObj<typeof meta>;

export const Default: Story = {
  render(args) {
    const [checked, setChecked] = useState(args.checked);

    return (
      <Gapped>
        <Checkbox
          {...args}
          data-attribute-without-value={""}
          data-tid={CheckboxTestIds.CheckboxId}
          checked={checked}
          onValueChange={setChecked}
        >
          TODO
        </Checkbox>
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

export const InitialIndeterminate: Story = {
  ...Default,
  args: {
    initialIndeterminate: true,
  },
};

export const Checked: Story = {
  ...Default,
  args: {
    checked: true,
  },
};

export const WithValue: Story = {
  ...Default,
  args: {
    value: "CheckboxValue",
  },
};

export const WithTooltip: Story = {
  render: () => (
    <Gapped>
      <Tooltip render={() => <div>TooltipText</div>}>
        <Checkbox data-tid={CheckboxTestIds.CheckboxId}>TODO</Checkbox>
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
        {isVisible && (
          <Checkbox data-tid={CheckboxTestIds.CheckboxId}>TODO</Checkbox>
        )}
      </Gapped>
    );
  },
};

export const FocusAndBlur: Story = {
  render: () => {
    const [isShowLabel, setShowLabel] = useState(false);

    return (
      <Gapped>
        <Checkbox
          data-tid={CheckboxTestIds.CheckboxId}
          onFocus={() => setShowLabel(true)}
          onBlur={() => setShowLabel(false)}
        >
          TODO
        </Checkbox>
        {isShowLabel && (
          <div data-tid={CheckboxTestIds.LabelId}>Hello world!</div>
        )}
      </Gapped>
    );
  },
};
