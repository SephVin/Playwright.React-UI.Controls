import type { Meta, StoryObj } from "@storybook/react";
import type { ComboBoxItem, ComboBoxProps } from "@skbkontur/react-ui";
import { MenuItem } from "@skbkontur/react-ui";
import { ComboBox, Gapped, Tooltip } from "@skbkontur/react-ui";
// eslint-disable-next-line
import React, { useEffect, useState } from "react";

import {
  getNumbers,
  getNumbersWithDelay,
  numbers,
} from "./utils/comboboxItemsProvider";

export enum ComboBoxTestIds {
  ComboBoxId = "ComboBoxId",
}

const ComboBoxTemplate = (props: ComboBoxProps<ComboBoxItem>) => {
  const [selectedNumber, selectNumber] = useState<ComboBoxItem>();

  return (
    <Gapped>
      <ComboBox
        data-attribute-without-value={""}
        data-tid={ComboBoxTestIds.ComboBoxId}
        value={selectedNumber}
        placeholder="placeholderValue"
        renderAddButton={() => <MenuItem>MenuItem</MenuItem>}
        {...props}
        getItems={getNumbers}
        onValueChange={selectNumber}
      />
    </Gapped>
  );
};

const meta: Meta<typeof ComboBoxTemplate> = {
  title: "ComboBox",
  component: ComboBoxTemplate,
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

export const Loading: Story = {
  render: () => {
    const [selectedNumber, selectNumber] = useState<ComboBoxItem>();

    return (
      <Gapped>
        <ComboBox
          data-tid={ComboBoxTestIds.ComboBoxId}
          getItems={getNumbersWithDelay}
          onValueChange={selectNumber}
          value={selectedNumber}
          renderAddButton={() => <MenuItem>MenuItem</MenuItem>}
        />
      </Gapped>
    );
  },
};

export const Filled: Story = {
  render: () => {
    const [selectedNumber, selectNumber] = useState<ComboBoxItem>(numbers[0]);

    return (
      <Gapped>
        <ComboBox
          data-tid={ComboBoxTestIds.ComboBoxId}
          getItems={getNumbers}
          onValueChange={selectNumber}
          value={selectedNumber}
        />
      </Gapped>
    );
  },
};

export const Hidden: Story = {
  render: () => {
    const [isVisible, setIsVisible] = useState(true);
    const [selectedNumber, selectNumber] = useState<ComboBoxItem>();

    useEffect(() => {
      const timer = setTimeout(() => {
        setIsVisible(false);
      }, 2000);

      return () => clearTimeout(timer);
    }, []);

    return (
      <Gapped>
        {isVisible && (
          <ComboBox
            data-tid={ComboBoxTestIds.ComboBoxId}
            getItems={getNumbers}
            onValueChange={selectNumber}
            value={selectedNumber}
          />
        )}
      </Gapped>
    );
  },
};

export const WithTooltip: Story = {
  render: () => {
    const [selectedNumber, selectNumber] = useState<ComboBoxItem>();

    return (
      <Gapped>
        <Tooltip render={() => <div>TooltipText</div>}>
          <ComboBox
            data-tid={ComboBoxTestIds.ComboBoxId}
            getItems={getNumbers}
            onValueChange={selectNumber}
            value={selectedNumber}
          />
        </Tooltip>
      </Gapped>
    );
  },
};
