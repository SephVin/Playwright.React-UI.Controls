import type { Meta, StoryObj } from "@storybook/react";
import { Gapped, Tabs, Tooltip } from "@skbkontur/react-ui";
import React, { useEffect, useState } from "react";

export enum TabsTestIds {
  TabsId = "TabsId",
}

export enum TabName {
  First = "First",
  Second = "Second",
  Third = "Third",
  Fourth = "Fourth",
}

const meta: Meta<typeof Tabs> = {
  title: "Tabs",
  component: Tabs,
};
export default meta;
type Story = StoryObj<typeof meta>;

export const Default: Story = {
  render(args) {
    const [tab, setActive] = useState(args.value ?? TabName.First);

    return (
      <Gapped>
        <Tabs
          {...args}
          data-attribute-without-value={""}
          data-tid={TabsTestIds.TabsId}
          value={tab}
          onValueChange={setActive}
        >
          {Object.keys(TabName).map((tab) => (
            <Tabs.Tab
              id={tab}
              key={tab}
              disabled={tab === TabName.Second}
              warning={tab === TabName.Third}
              error={tab === TabName.Fourth}
            >
              {tab}
            </Tabs.Tab>
          ))}
        </Tabs>
      </Gapped>
    );
  },
};

export const WithTooltip: Story = {
  render: () => {
    const [active, setActive] = useState(TabName.First);

    return (
      <Gapped>
        <Tabs
          data-tid={TabsTestIds.TabsId}
          value={active}
          onValueChange={setActive}
        >
          <Tooltip render={() => <div>TooltipText</div>}>
            <Tabs.Tab data-attribute-without-value={""} id={TabName.First}>
              First
            </Tabs.Tab>
          </Tooltip>
          <Tabs.Tab id={TabName.Second}>Second</Tabs.Tab>
        </Tabs>
      </Gapped>
    );
  },
};

export const Hidden: Story = {
  render: () => {
    const [active, setActive] = useState(TabName.First);
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
          <Tabs
            data-tid={TabsTestIds.TabsId}
            value={active}
            onValueChange={setActive}
          >
            <Tooltip render={() => <div>TooltipText</div>}>
              <Tabs.Tab id={TabName.First}>First</Tabs.Tab>
            </Tooltip>
            <Tabs.Tab id={TabName.Second}>Second</Tabs.Tab>
          </Tabs>
        )}
      </Gapped>
    );
  },
};
