import React, { useEffect, useState } from "react";
import { Gapped, Paging, PagingProps } from "@skbkontur/react-ui";
import { Meta, type StoryObj } from "@storybook/react";

export enum PagingTestIds {
  PagingId = "PagingId",
}

const PagingTemplate = (props: PagingProps) => {
  const [activePage, setActivePage] = useState(2);

  return (
    <Gapped>
      <Paging
        {...props}
        data-tid={PagingTestIds.PagingId}
        onPageChange={(activePage) => setActivePage(activePage)}
        activePage={activePage}
        pagesCount={8}
      />
    </Gapped>
  );
};

const meta: Meta<typeof PagingTemplate> = {
  title: "Paging",
  component: PagingTemplate,
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

export const OnLastPage: Story = {
  render: () => {
    const [activePage, setActivePage] = useState(8);

    return (
      <Gapped>
        <Paging
          data-tid={PagingTestIds.PagingId}
          onPageChange={(activePage) => setActivePage(activePage)}
          activePage={activePage}
          pagesCount={8}
        />
      </Gapped>
    );
  },
};

export const Hidden: Story = {
  render: () => {
    const [isVisible, setIsVisible] = useState(true);
    const [activePage, setActivePage] = useState(8);

    useEffect(() => {
      const timer = setTimeout(() => {
        setIsVisible(false);
      }, 2000);

      return () => clearTimeout(timer);
    }, []);

    return (
      <Gapped>
        {isVisible && (
          <Paging
            data-tid={PagingTestIds.PagingId}
            onPageChange={(activePage) => setActivePage(activePage)}
            activePage={activePage}
            pagesCount={8}
          />
        )}
      </Gapped>
    );
  },
};
