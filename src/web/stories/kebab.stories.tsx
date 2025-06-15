import React, { useEffect, useState } from "react";
import {
  Gapped,
  Kebab,
  KebabProps,
  MenuItem,
  Toast,
  Tooltip,
} from "@skbkontur/react-ui";
import { Meta, type StoryObj } from "@storybook/react";
import { style } from "./utils/kebabStyles";
import { DropdownTestIds } from "./dropdown.stories";

export enum KebabTestIds {
  KebabId = "KebabId",
  TODO1 = "TODO1",
  TODO2 = "TODO2",
  LabelId = "LabelId",
}

const KebabTemplate = (props: KebabProps) => {
  let Card = () => (
    <div style={style}>
      <div>
        <h3>TODO</h3>
      </div>

      <Kebab
        data-attribute-without-value={""}
        data-tid={KebabTestIds.KebabId}
        size={"small"}
        {...props}
      >
        <MenuItem onClick={() => Toast.push("Clicked TODO 1")}>TODO 1</MenuItem>
        <MenuItem onClick={() => Toast.push("Clicked TODO 2")}>TODO 2</MenuItem>
      </Kebab>
    </div>
  );

  return (
    <Gapped>
      <Card />
    </Gapped>
  );
};

const meta: Meta<typeof KebabTemplate> = {
  title: "Kebab",
  component: KebabTemplate,
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

export const WithTooltip: Story = {
  render: () => {
    let Card = () => (
      <div style={style}>
        <div>
          <h3>TODO</h3>
        </div>

        <Kebab data-tid={KebabTestIds.KebabId} size={"small"}>
          <MenuItem onClick={() => Toast.push("Clicked TODO 1")}>
            TODO 1
          </MenuItem>
          <MenuItem onClick={() => Toast.push("Clicked TODO 2")}>
            TODO 2
          </MenuItem>
        </Kebab>
      </div>
    );

    return (
      <Gapped>
        <Tooltip render={() => <div>TooltipText</div>} closeButton>
          <Card />
        </Tooltip>
      </Gapped>
    );
  },
};

export const WithMenuDataTid: Story = {
  render: () => {
    let Card = () => (
      <div style={style}>
        <div>
          <h3>TODO</h3>
        </div>

        <Kebab data-tid={KebabTestIds.KebabId} size={"small"}>
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
        </Kebab>
      </div>
    );

    return (
      <Gapped>
        <Card />
      </Gapped>
    );
  },
};

export const Hidden: Story = {
  render: () => {
    let Card = () => (
      <div style={style}>
        <div>
          <h3>TODO</h3>
        </div>

        <Kebab data-tid={KebabTestIds.KebabId} size={"small"}>
          <MenuItem onClick={() => Toast.push("Clicked TODO 1")}>
            TODO 1
          </MenuItem>
          <MenuItem onClick={() => Toast.push("Clicked TODO 2")}>
            TODO 2
          </MenuItem>
        </Kebab>
      </div>
    );

    const [isVisible, setIsVisible] = useState(true);

    useEffect(() => {
      const timer = setTimeout(() => {
        setIsVisible(false);
      }, 2000);

      return () => clearTimeout(timer);
    }, []);

    return <Gapped>{isVisible && <Card />}</Gapped>;
  },
};
