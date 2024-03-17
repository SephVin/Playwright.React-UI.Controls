import React, { useState } from "react";
import { Autocomplete, Gapped } from "@skbkontur/react-ui";
import { Meta } from "@storybook/react";

export default {
  title: "Autocomplete",
} as Meta;

export const Default = () => {
  const items = ["Grey Face", "Grey Space", "Resident Sleeper"];
  const [value, setValue] = useState("");

  return (
    <Gapped>
      <Autocomplete
        data-tid="AutocompleteId"
        source={items}
        value={value}
        onValueChange={setValue}
      />
    </Gapped>
  );
};

export const Disabled = () => {
  const items = ["Grey Face", "Grey Space", "Resident Sleeper"];
  const [value, setValue] = useState("");

  return (
    <Gapped>
      <Autocomplete
        data-tid="AutocompleteId"
        source={items}
        value={value}
        onValueChange={setValue}
        disabled
      />
    </Gapped>
  );
};

export const Error = () => {
  const items = ["Grey Face", "Grey Space", "Resident Sleeper"];
  const [value, setValue] = useState("");

  return (
    <Gapped>
      <Autocomplete
        data-tid="AutocompleteId"
        source={items}
        value={value}
        onValueChange={setValue}
        error
      />
    </Gapped>
  );
};

export const Warning = () => {
  const items = ["Grey Face", "Grey Space", "Resident Sleeper"];
  const [value, setValue] = useState("");

  return (
    <Gapped>
      <Autocomplete
        data-tid="AutocompleteId"
        source={items}
        value={value}
        onValueChange={setValue}
        warning
      />
    </Gapped>
  );
};

export const Filled = () => {
  const items = ["Grey Face", "Grey Space", "Resident Sleeper"];
  const [value, setValue] = useState("Resident Sleeper");

  return (
    <Gapped>
      <Autocomplete
        data-tid="AutocompleteId"
        source={items}
        value={value}
        onValueChange={setValue}
      />
    </Gapped>
  );
};
