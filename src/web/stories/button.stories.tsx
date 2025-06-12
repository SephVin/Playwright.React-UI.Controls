import React, { useEffect, useState } from "react";
import type { ButtonProps } from "@skbkontur/react-ui";
import { Button, Gapped, Toast, Tooltip } from "@skbkontur/react-ui";
import type { Meta, StoryObj } from "@storybook/react";

export enum ButtonTestIds {
  ButtonId = "ButtonId",
  LabelId = "LabelId",
}

const ButtonTemplate = (props: ButtonProps) => {
  return (
    <Gapped>
      <Button
        data-attribute-without-value={""}
        data-tid={ButtonTestIds.ButtonId}
        onClick={() => Toast.push("Clicked")}
        {...props}
      >
        TODO
      </Button>
    </Gapped>
  );
};

const meta: Meta<typeof ButtonTemplate> = {
  title: "Button",
  component: ButtonTemplate,
};
export default meta;

type Story = StoryObj<typeof meta>;

export const Default: Story = {};

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

export const Loading: Story = {
  ...Default,
  args: {
    loading: true,
  },
};

export const WithTooltip: Story = {
  render: () => (
    <Gapped>
      <Tooltip
        data-attribute-without-value={""}
        render={() => (
          <div>
            TooltipText <a href="https://kontur.ru">ссылка</a>
          </div>
        )}
        closeButton
      >
        <Button data-tid={ButtonTestIds.ButtonId}>TODO</Button>
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
        {isVisible && <Button data-tid={ButtonTestIds.ButtonId}>TODO</Button>}
      </Gapped>
    );
  },
};

export const FocusAndBlur: Story = {
  render: () => {
    const [isShowLabel, setShowLabel] = useState(false);

    return (
      <Gapped>
        <Button
          data-tid={ButtonTestIds.ButtonId}
          onFocus={() => setShowLabel(true)}
          onBlur={() => setShowLabel(false)}
        >
          TODO
        </Button>
        {isShowLabel && (
          <div data-tid={ButtonTestIds.LabelId}>Hello world!</div>
        )}
      </Gapped>
    );
  },
};
