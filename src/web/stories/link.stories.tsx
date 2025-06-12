import type { LinkProps } from "@skbkontur/react-ui";
import { Gapped, Link, Tooltip } from "@skbkontur/react-ui";
import React, { useEffect, useState } from "react";
import type { Meta, StoryObj } from "@storybook/react";

export enum LinkTestIds {
  LinkId = "LinkId",
}

const LinkTemplate = (props: LinkProps) => {
  return (
    <Gapped>
      <Link
        {...props}
        data-attribute-without-value={""}
        data-tid={LinkTestIds.LinkId}
        href="https://google.com/"
      >
        TODO
      </Link>
    </Gapped>
  );
};

const meta: Meta<typeof LinkTemplate> = {
  title: "Link",
  component: LinkTemplate,
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
  render: () => (
    <Gapped>
      <Tooltip render={() => <div>TooltipText</div>}>
        <Link data-tid={LinkTestIds.LinkId} href="https://google.com/">
          TODO
        </Link>
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
          <Link data-tid={LinkTestIds.LinkId} href="https://google.com/">
            TODO
          </Link>
        )}
      </Gapped>
    );
  },
};
