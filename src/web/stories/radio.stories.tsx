import type { Meta, StoryObj } from "@storybook/react";
import { Gapped, Radio, Tooltip } from "@skbkontur/react-ui";
import React, { useEffect, useState } from "react";

export enum RadioTestIds {
  RadioId = "RadioId",
  LabelId = "LabelId",
}

const meta: Meta<typeof Radio> = {
  title: "Radio",
  component: Radio,
};
export default meta;

type Story = StoryObj<typeof meta>;

export const Default: Story = {
  render(args) {
    const [chosen, setChosen] = useState(args.checked);

    return (
      <Gapped>
        <Radio
          {...args}
          data-attribute-without-value={""}
          data-tid={RadioTestIds.RadioId}
          checked={chosen}
          onValueChange={(_) => setChosen(chosen)}
        >
          TODO
        </Radio>
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

export const Checked: Story = {
  ...Default,
  args: {
    checked: true,
  },
};

export const WithValue: Story = {
  ...Default,
  args: {
    value: "RadioValue",
  },
};

export const WithTooltip: Story = {
  render: () => (
    <Gapped>
      <Tooltip render={() => <div>TooltipText</div>}>
        <Radio data-tid={RadioTestIds.RadioId} value="1">
          TODO
        </Radio>
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
          <Radio data-tid={RadioTestIds.RadioId} value="1">
            TODO
          </Radio>
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
        <Radio
          data-tid={RadioTestIds.RadioId}
          value="1"
          onFocus={() => setShowLabel(true)}
          onBlur={() => setShowLabel(false)}
        >
          TODO
        </Radio>
        {isShowLabel && <div data-tid={RadioTestIds.LabelId}>Hello world!</div>}
      </Gapped>
    );
  },
};
