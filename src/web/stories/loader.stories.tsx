import type { Meta, StoryObj } from '@storybook/react';
import { Gapped, Loader } from '@skbkontur/react-ui';
import React, { useEffect, useState } from 'react';

const meta: Meta<typeof Loader> = {
  title: 'Loader',
  component: Loader,
};
export default meta;

type Story = StoryObj<typeof meta>;

export const Default: Story = {
  render() {
    return (
      <Gapped>
        <Loader type="big" caption="Loading" active />
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
        <Loader type="big" active={isVisible} />
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
        <Loader type="big" active={isVisible} />
      </Gapped>
    );
  },
};
