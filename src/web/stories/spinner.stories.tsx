import type { Meta, StoryObj } from '@storybook/react';
import { Gapped, Spinner } from '@skbkontur/react-ui';
import React, { useEffect, useState } from 'react';

export enum SpinnerTestIds {
  SpinnerId = 'SpinnerId',
}

const meta: Meta<typeof Spinner> = {
  title: 'Spinner',
  component: Spinner,
};
export default meta;

type Story = StoryObj<typeof meta>;

export const Default: Story = {
  render() {
    return (
      <Gapped>
        <Spinner data-tid={SpinnerTestIds.SpinnerId} caption="Loading" />
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

    return <Gapped>{isVisible && <Spinner data-tid={SpinnerTestIds.SpinnerId} />}</Gapped>;
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

    return <Gapped>{isVisible && <Spinner data-tid={SpinnerTestIds.SpinnerId} />}</Gapped>;
  },
};
