import type { TokenInputProps } from '@skbkontur/react-ui';
import { Tooltip, TokenInputType, Token, TokenInput, Gapped } from '@skbkontur/react-ui';
import React, { useEffect, useState } from 'react';
import type { Meta, StoryObj } from '@storybook/react';

import { getItems } from './utils/tokenItemsProvider';

export enum TokenInputTestIds {
  TokenInputId = 'TokenInputId',
}

const TokenInputTemplate = (props: TokenInputProps<string>) => {
  const [selectedItems, setSelectedItems] = React.useState<string[]>([]);

  return (
    <Gapped>
      <TokenInput
        data-attribute-without-value={''}
        type={TokenInputType.Combined}
        data-tid={TokenInputTestIds.TokenInputId}
        getItems={getItems}
        selectedItems={selectedItems}
        onValueChange={setSelectedItems}
        placeholder="PlaceholderText"
        {...props}
      />
    </Gapped>
  );
};

const meta: Meta<typeof TokenInputTemplate> = {
  title: 'TokenInput',
  component: TokenInputTemplate,
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
export const DisabledToken: Story = {
  args: {
    ...Default.args,
    renderToken: (item, tokenProps) => (
      <Token key={item.toString()} {...tokenProps} disabled={item === 'Second' || tokenProps.disabled}>
        {item}
      </Token>
    ),
  },
};

export const Error: Story = {
  args: {
    ...Default.args,
    error: true,
  },
};

export const ErrorToken: Story = {
  args: {
    ...Default.args,
    renderToken: (item, tokenProps) => (
      <Token
        data-attribute-without-value={''}
        key={item.toString()}
        {...tokenProps}
        error={item === 'Second' || tokenProps.error}
      >
        {item}
      </Token>
    ),
  },
};

export const Warning: Story = {
  args: {
    ...Default.args,
    warning: true,
  },
};

export const WarningToken: Story = {
  args: {
    ...Default.args,
    renderToken: (item, tokenProps) => (
      <Token key={item.toString()} {...tokenProps} warning={item === 'Second' || tokenProps.error}>
        {item}
      </Token>
    ),
  },
};

export const Filled: Story = {
  render: () => {
    const [selectedItems, setSelectedItems] = React.useState(['First', 'Second']);

    return (
      <Gapped>
        <TokenInput
          data-tid={TokenInputTestIds.TokenInputId}
          getItems={getItems}
          selectedItems={selectedItems}
          onValueChange={setSelectedItems}
        />
      </Gapped>
    );
  },
};

export const Hidden: Story = {
  render: () => {
    const [isVisible, setIsVisible] = useState(true);
    const [selectedItems, setSelectedItems] = React.useState<string[]>([]);

    useEffect(() => {
      const timer = setTimeout(() => {
        setIsVisible(false);
      }, 2000);

      return () => clearTimeout(timer);
    }, []);

    return (
      <Gapped>
        {isVisible && (
          <TokenInput
            data-tid={TokenInputTestIds.TokenInputId}
            getItems={getItems}
            selectedItems={selectedItems}
            onValueChange={setSelectedItems}
          />
        )}
      </Gapped>
    );
  },
};

export const WithTooltip: Story = {
  render: () => {
    const [selectedItems, setSelectedItems] = React.useState<string[]>([]);

    return (
      <Gapped>
        <Tooltip render={() => <div>TooltipText</div>}>
          <TokenInput
            data-tid={TokenInputTestIds.TokenInputId}
            getItems={getItems}
            selectedItems={selectedItems}
            onValueChange={setSelectedItems}
          />
        </Tooltip>
      </Gapped>
    );
  },
};
