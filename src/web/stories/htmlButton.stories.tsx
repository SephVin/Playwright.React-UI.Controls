import type { Meta, StoryObj } from "@storybook/react";
// eslint-disable-next-line
import React, { useEffect, useState } from "react";
import { Gapped, Toast, Tooltip } from "@skbkontur/react-ui";

export enum HtmlButtonTestIds {
  HtmlButtonId = "ButtonId",
  LabelId = "LabelId",
}

const meta: Meta = {
  title: "HtmlButton",
};

export default meta;
type Story = StoryObj<typeof meta>;

export const Default: Story = {
  render(args) {
    return (
      <Gapped>
        <button
          data-attribute-without-value={""}
          data-tid={HtmlButtonTestIds.HtmlButtonId}
          onClick={() => Toast.push("Clicked")}
          {...args}
        >
          TODO
        </button>
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

export const WithTooltip: Story = {
  render: () => (
    <Gapped>
      <Tooltip
        render={() => (
          <div>
            TooltipText <a href="https://kontur.ru">ссылка</a>
          </div>
        )}
      >
        <button data-tid={HtmlButtonTestIds.HtmlButtonId}>TODO</button>
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
          <button data-tid={HtmlButtonTestIds.HtmlButtonId}>TODO</button>
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
        <button
          data-tid={HtmlButtonTestIds.HtmlButtonId}
          onFocus={() => setShowLabel(true)}
          onBlur={() => setShowLabel(false)}
        >
          TODO
        </button>
        {isShowLabel && (
          <div data-tid={HtmlButtonTestIds.LabelId}>Hello world!</div>
        )}
      </Gapped>
    );
  },
};
