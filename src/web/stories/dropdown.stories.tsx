import type { Meta, StoryObj } from "@storybook/react";
import type { DropdownProps } from "@skbkontur/react-ui";
import { Tooltip } from "@skbkontur/react-ui";
import { MenuHeader, MenuSeparator } from "@skbkontur/react-ui";
import { Dropdown, Gapped, MenuItem, Toast } from "@skbkontur/react-ui";
import React, { useEffect, useState } from "react";

export enum DropdownTestIds {
  DropdownId = "DropdownId",
  TODO1 = "TODO1",
  TODO2 = "TODO2",
  LabelId = "LabelId",
}

const DropdownTemplate = (props: DropdownProps) => {
  const [isShowLabel, setShowLabel] = useState(false);

  return (
    <Gapped>
      <Dropdown
        data-attribute-without-value={""}
        data-tid={DropdownTestIds.DropdownId}
        onOpen={() => setShowLabel(true)}
        {...props}
        caption="TODO"
      >
        <MenuItem onClick={() => Toast.push("Clicked TODO 1")}>TODO 1</MenuItem>
        <MenuSeparator />
        <MenuHeader>Here goes the header</MenuHeader>
        <MenuItem onClick={() => Toast.push("Clicked TODO 2")}>TODO 2</MenuItem>
      </Dropdown>
      {isShowLabel && (
        <div data-tid={DropdownTestIds.LabelId}>Hello world!</div>
      )}
    </Gapped>
  );
};

const meta: Meta<typeof DropdownTemplate> = {
  title: "Dropdown",
  component: DropdownTemplate,
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

export const WithTooltip: Story = {
  render: () => (
    <Gapped>
      <Tooltip render={() => <div>TooltipText</div>} closeButton>
        <Dropdown data-tid={DropdownTestIds.DropdownId} caption="TODO">
          <MenuItem>TODO 1</MenuItem>
        </Dropdown>
      </Tooltip>
    </Gapped>
  ),
};

export const WithMenuDataTid: Story = {
  render: () => (
    <Gapped>
      <Dropdown data-tid={DropdownTestIds.DropdownId} caption="TODO">
        <MenuItem
          data-tid={DropdownTestIds.TODO1}
          onClick={() => Toast.push("Clicked TODO 1")}
        >
          TODO 1
        </MenuItem>
        <MenuItem
          data-tid={DropdownTestIds.TODO2}
          onClick={() => Toast.push("Clicked TODO 2")}
        >
          TODO 2
        </MenuItem>
      </Dropdown>
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
          <Dropdown data-tid={DropdownTestIds.DropdownId} caption="TODO">
            <MenuItem>TODO 1</MenuItem>
          </Dropdown>
        )}
      </Gapped>
    );
  },
};
