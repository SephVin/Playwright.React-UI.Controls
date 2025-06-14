import type { Meta, StoryObj } from "@storybook/react";
import { Gapped, Loader } from "@skbkontur/react-ui";
import React, { useEffect, useState } from "react";

export enum LoaderTestIds {
  LoaderId = "LoaderId",
}

const meta: Meta<typeof Loader> = {
  title: "Loader",
  component: Loader,
};
export default meta;

type Story = StoryObj<typeof meta>;

export const Default: Story = {
  render() {
    return (
      <Gapped>
        <Loader
          data-tid={LoaderTestIds.LoaderId}
          type="big"
          caption="Loading"
          active
        />
      </Gapped>
    );
  },
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
        <Loader
          data-tid={LoaderTestIds.LoaderId}
          type="big"
          active={isVisible}
        />
      </Gapped>
    );
  },
};

export const WaitLoading: Story = {
  render: () => {
    const [isVisible, setIsVisible] = useState(false);

    useEffect(() => {
      const timer = setTimeout(() => {
        setIsVisible(true);
      }, 2000);

      return () => clearTimeout(timer);
    }, []);

    return (
      <Gapped>
        <Loader
          data-tid={LoaderTestIds.LoaderId}
          type="big"
          active={isVisible}
        />
      </Gapped>
    );
  },
};
