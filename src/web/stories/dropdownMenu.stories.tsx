import {
  DropdownMenu,
  Gapped,
  MenuItem,
  Toast,
  Button,
  Checkbox,
  Tooltip,
  MenuSeparator,
  MenuHeader,
} from '@skbkontur/react-ui';
import type { Meta, StoryObj } from '@storybook/react';
import React, { useEffect, useState } from 'react';

export enum DropdownMenuTestIds {
  DropdownMenuId = 'DropdownMenuId',
  TODO1 = 'TODO1',
  TODO2 = 'TODO2',
  LabelId = 'LabelId',
  CheckboxId = 'CheckboxId',
}

const meta: Meta<typeof DropdownMenu> = {
  title: 'DropdownMenu',
  component: DropdownMenu,
};
export default meta;

type Story = StoryObj<typeof meta>;

export const Default: Story = {
  render() {
    const [isShowLabel, setShowLabel] = useState(false);

    return (
      <Gapped>
        <DropdownMenu
          data-attribute-without-value={''}
          data-tid={DropdownMenuTestIds.DropdownMenuId}
          onOpen={() => setShowLabel(true)}
          caption={<Button use="primary">TODO</Button>}
        >
          <MenuItem onClick={() => Toast.push('Clicked TODO 1')}>TODO 1</MenuItem>
          <MenuSeparator />
          <MenuHeader>Here goes the header</MenuHeader>
          <MenuItem onClick={() => Toast.push('Clicked TODO 2')}>TODO 2</MenuItem>
        </DropdownMenu>
        {isShowLabel && <div data-tid={DropdownMenuTestIds.LabelId}>Hello world!</div>}
      </Gapped>
    );
  },
};

export const NotClosed = () => {
  const [checked, setChecked] = useState(false);

  return (
    <Gapped>
      <DropdownMenu data-tid={DropdownMenuTestIds.DropdownMenuId} caption={<Button use="primary">TODO</Button>}>
        <MenuItem
          onClick={e => {
            e.preventDefault();
            setChecked(!checked);
          }}
        >
          <Checkbox checked={checked}>TODO 1</Checkbox>
        </MenuItem>
      </DropdownMenu>
    </Gapped>
  );
};

export const NotClosedWithMenuDataTid = () => {
  const [checked, setChecked] = useState(false);

  return (
    <Gapped>
      <DropdownMenu data-tid={DropdownMenuTestIds.DropdownMenuId} caption={<Button use="primary">TODO</Button>}>
        <MenuItem
          onClick={e => {
            e.preventDefault();
            setChecked(!checked);
          }}
        >
          <Checkbox data-tid={DropdownMenuTestIds.CheckboxId} checked={checked}>
            TODO 1
          </Checkbox>
        </MenuItem>
      </DropdownMenu>
    </Gapped>
  );
};

export const WithTooltip: Story = {
  render: () => (
    <Gapped>
      <Tooltip render={() => <div>TooltipText</div>} closeButton>
        <DropdownMenu
          data-attribute-without-value={''}
          data-tid={DropdownMenuTestIds.DropdownMenuId}
          caption={<Button use="primary">TODO</Button>}
        >
          <MenuItem>TODO 1</MenuItem>
        </DropdownMenu>
      </Tooltip>
    </Gapped>
  ),
};

export const WithMenuDataTid: Story = {
  render: () => (
    <Gapped>
      <DropdownMenu
        data-attribute-without-value={''}
        data-tid={DropdownMenuTestIds.DropdownMenuId}
        caption={<Button use="primary">TODO</Button>}
      >
        <MenuItem data-tid={DropdownMenuTestIds.TODO1} onClick={() => Toast.push('Clicked TODO 1')}>
          TODO 1
        </MenuItem>
        <MenuItem data-tid={DropdownMenuTestIds.TODO2} onClick={() => Toast.push('Clicked TODO 2')}>
          TODO 2
        </MenuItem>
      </DropdownMenu>
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
          <DropdownMenu data-tid={DropdownMenuTestIds.DropdownMenuId} caption={<Button use="primary">TODO</Button>}>
            <MenuItem>TODO 1</MenuItem>
          </DropdownMenu>
        )}
      </Gapped>
    );
  },
};
