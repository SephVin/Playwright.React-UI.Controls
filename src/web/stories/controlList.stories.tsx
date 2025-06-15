import type { Meta, StoryObj } from "@storybook/react";
import { Gapped, Radio, RadioGroup, Tooltip } from "@skbkontur/react-ui";
import React, { useEffect, useState } from "react";

export enum ControlListTestIds {
  RootId = "RootId",
}

const meta: Meta = {
  title: "ControlList",
};

export default meta;

type Story = StoryObj<typeof meta>;

export const Default: Story = {
  render() {
    const [chosen, setChosen] = useState(0);

    return (
      <Gapped>
        <RadioGroup
          data-attribute-without-value={""}
          data-tid={ControlListTestIds.RootId}
          value={chosen}
          onValueChange={(value) => setChosen(value)}
        >
          <Gapped gap={3} vertical>
            <Radio value={1}>TODO 1</Radio>
            <Radio value={2}>TODO 2</Radio>
            <Radio value={3}>TODO 3</Radio>
          </Gapped>
        </RadioGroup>
      </Gapped>
    );
  },
};

export const Hidden: Story = {
  render: () => {
    const [isVisible, setIsVisible] = useState(true);
    const [chosen, setChosen] = useState(0);

    useEffect(() => {
      const timer = setTimeout(() => {
        setIsVisible(false);
      }, 2000);

      return () => clearTimeout(timer);
    }, []);

    return (
      <Gapped>
        {isVisible && (
          <RadioGroup
            data-tid={ControlListTestIds.RootId}
            value={chosen}
            onValueChange={(value) => setChosen(value)}
          >
            <Gapped gap={3} vertical>
              <Radio value={1}>TODO 1</Radio>
              <Radio value={2}>TODO 2</Radio>
              <Radio value={3}>TODO 3</Radio>
            </Gapped>
          </RadioGroup>
        )}
      </Gapped>
    );
  },
};

export const WithTooltip: Story = {
  render: () => {
    const [chosen, setChosen] = useState(0);

    return (
      <Gapped>
        <Tooltip render={() => <div>TooltipText</div>}>
          <RadioGroup
            data-tid={ControlListTestIds.RootId}
            value={chosen}
            onValueChange={(value) => setChosen(value)}
          >
            <Gapped gap={3} vertical>
              <Radio value={1}>TODO 1</Radio>
              <Radio value={2}>TODO 2</Radio>
              <Radio value={3}>TODO 3</Radio>
            </Gapped>
          </RadioGroup>
        </Tooltip>
      </Gapped>
    );
  },
};

export const SingleElement: Story = {
  render: () => {
    const [chosen, setChosen] = useState(0);

    return (
      <Gapped>
        <RadioGroup
          data-tid={ControlListTestIds.RootId}
          value={chosen}
          onValueChange={(value) => setChosen(value)}
        >
          <Gapped gap={3} vertical>
            <Radio value={1}>TODO 1</Radio>
          </Gapped>
        </RadioGroup>
      </Gapped>
    );
  },
};
