import React, { useEffect, useState } from "react";
import { Autocomplete, Gapped, Tooltip } from "@skbkontur/react-ui";
import { Meta, type StoryObj } from "@storybook/react";

export enum AutocompleteTestIds {
  AutocompleteId = "AutocompleteId",
}

const meta: Meta<typeof Autocomplete> = {
  title: "Autocomplete",
  component: Autocomplete,
};
export default meta;

type Story = StoryObj<typeof meta>;

export const Default: Story = {
  render(args) {
    const items = ["Grey Face", "Grey Space", "Resident Sleeper"];
    const [value, setValue] = useState("");

    return (
      <Gapped>
        <Autocomplete
          {...args}
          data-attribute-without-value={""}
          data-tid={AutocompleteTestIds.AutocompleteId}
          source={items}
          value={value}
          onValueChange={setValue}
        />
      </Gapped>
    );
  },
};

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
    const items = ["Grey Face", "Grey Space", "Resident Sleeper"];
    const [value, setValue] = useState("Resident Sleeper");

    return (
      <Gapped>
        <Autocomplete
          data-tid={AutocompleteTestIds.AutocompleteId}
          source={items}
          value={value}
          onValueChange={setValue}
        />
      </Gapped>
    );
  },
};

export const Hidden: Story = {
  render: () => {
    const items = ["Grey Face", "Grey Space", "Resident Sleeper"];
    const [value, setValue] = useState("");
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
          <Autocomplete
            data-tid={AutocompleteTestIds.AutocompleteId}
            source={items}
            value={value}
            onValueChange={setValue}
          />
        )}
      </Gapped>
    );
  },
};

export const WithTooltip: Story = {
  render: () => {
    const items = ["Grey Face", "Grey Space", "Resident Sleeper"];
    const [value, setValue] = useState("");
    return (
      <Gapped>
        <Tooltip render={() => <div>TooltipText</div>}>
          <Autocomplete
            data-tid={AutocompleteTestIds.AutocompleteId}
            source={items}
            value={value}
            onValueChange={setValue}
          />
        </Tooltip>
      </Gapped>
    );
  },
};
