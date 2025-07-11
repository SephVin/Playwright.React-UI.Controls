import type { Meta, StoryObj } from "@storybook/react";
import {
  type TextareaProps,
  Gapped,
  Textarea,
  Tooltip,
} from "@skbkontur/react-ui";
import React, { useEffect, useState } from "react";

export enum TextareaTestIds {
  TextareaId = "TextareaId",
}

const TextareaTemplate = (props: TextareaProps) => {
  const [value, setValue] = useState(props.value);

  return (
    <Gapped>
      <Textarea
        {...props}
        data-attribute-without-value={""}
        data-tid={TextareaTestIds.TextareaId}
        value={value}
        onValueChange={setValue}
        placeholder="PlaceholderText"
      />
    </Gapped>
  );
};

const meta: Meta<typeof TextareaTemplate> = {
  title: "Textarea",
  component: TextareaTemplate,
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
    value: "TODO",
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
          <Textarea
            data-tid={TextareaTestIds.TextareaId}
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
          <Textarea
            data-tid={TextareaTestIds.TextareaId}
            value={value}
            onValueChange={setValue}
          />
        </Tooltip>
      </Gapped>
    );
  },
};
