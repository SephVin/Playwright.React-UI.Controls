import React, { useEffect, useState } from 'react';
import type { FxInputProps } from '@skbkontur/react-ui';
import { FxInput, Gapped, Tooltip } from '@skbkontur/react-ui';
import type { Meta } from '@storybook/react';
import { type StoryObj } from '@storybook/react';

export enum FxInputTestIds {
  FxInputId = 'FxInputId',
}

export const FxInputTemplate = (props: FxInputProps) => {
  const [auto, setAuto] = useState(false);
  const [value, setValue] = useState('');

  function handleValueChange(value: string) {
    setAuto(false);
    setValue(value);
  }

  function handleRestore() {
    setAuto(true);
    setValue('auto');
  }

  return (
    <Gapped>
      <FxInput
        {...props}
        data-tid={FxInputTestIds.FxInputId}
        data-attribute-without-value={''}
        auto={auto}
        value={value}
        onValueChange={handleValueChange}
        onRestore={handleRestore}
      />
    </Gapped>
  );
};

const meta: Meta<typeof FxInput> = {
  title: 'FxInput',
  component: FxInputTemplate,
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

export const Error: Story = {
  ...Default,
  args: {
    error: true,
  },
};

export const Warning: Story = {
  ...Default,
  args: {
    warning: true,
  },
};

export const Filled: Story = {
  render: () => {
    const [auto, setAuto] = useState(false);
    const [value, setValue] = useState('TODO');

    function handleValueChange(value: string) {
      setAuto(false);
      setValue(value);
    }

    function handleRestore() {
      setAuto(true);
      setValue('auto');
    }

    return (
      <Gapped>
        <FxInput
          data-tid={FxInputTestIds.FxInputId}
          auto={auto}
          value={value}
          onValueChange={handleValueChange}
          onRestore={handleRestore}
        />
      </Gapped>
    );
  },
};

export const Auto: Story = {
  render: () => {
    const [value, setValue] = useState('TODO');

    function handleValueChange(value: string) {
      setValue(value);
    }

    function handleRestore() {
      setValue('auto');
    }

    return (
      <Gapped>
        <FxInput
          data-tid={FxInputTestIds.FxInputId}
          auto={true}
          value={value}
          onValueChange={handleValueChange}
          onRestore={handleRestore}
        />
      </Gapped>
    );
  },
};

export const Hidden: Story = {
  render: () => {
    const [isVisible, setIsVisible] = useState(true);
    const [auto, setAuto] = useState(false);
    const [value, setValue] = useState('');

    function handleValueChange(value: string) {
      setAuto(false);
      setValue(value);
    }

    function handleRestore() {
      setAuto(true);
      setValue('auto');
    }

    useEffect(() => {
      const timer = setTimeout(() => {
        setIsVisible(false);
      }, 2000);

      return () => clearTimeout(timer);
    }, []);

    return (
      <Gapped>
        {isVisible && (
          <FxInput
            data-tid={FxInputTestIds.FxInputId}
            auto={auto}
            value={value}
            onValueChange={handleValueChange}
            onRestore={handleRestore}
          />
        )}
      </Gapped>
    );
  },
};

export const WithTooltip: Story = {
  render: () => {
    const [auto, setAuto] = useState(false);
    const [value, setValue] = useState('');

    function handleValueChange(value: string) {
      setAuto(false);
      setValue(value);
    }

    function handleRestore() {
      setAuto(true);
      setValue('auto');
    }
    return (
      <Gapped>
        <Tooltip render={() => <div>TooltipText</div>}>
          <FxInput
            data-tid={FxInputTestIds.FxInputId}
            auto={auto}
            value={value}
            onValueChange={handleValueChange}
            onRestore={handleRestore}
          />
        </Tooltip>
      </Gapped>
    );
  },
};
