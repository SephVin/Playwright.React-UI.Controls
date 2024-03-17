import React, { useState } from "react";
import { Gapped, Tabs } from "@skbkontur/react-ui";
import { Meta } from "@storybook/react";

export default {
  title: "Tab",
} as Meta;

export const Default = () => {
  const [active, setActive] = useState("fuji");

  return (
    <Gapped>
      <Tabs value={active} onValueChange={setActive}>
        <Tabs.Tab data-tid="TabId1" id="fuji" data-active={active == "fuji"}>
          Fuji
        </Tabs.Tab>
        <Tabs.Tab data-tid="TabId2" id="tahat" data-active={active == "tahat"}>
          Tahat
        </Tabs.Tab>
      </Tabs>
    </Gapped>
  );
};

export const Disabled = () => {
  const [active, setActive] = useState("fuji");

  return (
    <Gapped>
      <Tabs value={active} onValueChange={setActive}>
        <Tabs.Tab
          data-tid="TabId"
          id="fuji"
          data-active={active == "fuji"}
          disabled
        >
          Fuji
        </Tabs.Tab>
      </Tabs>
    </Gapped>
  );
};

export const Error = () => {
  const [active, setActive] = useState("fuji");

  return (
    <Gapped>
      <Tabs value={active} onValueChange={setActive}>
        <Tabs.Tab
          data-tid="TabId"
          id="fuji"
          data-active={active == "fuji"}
          error
        >
          Fuji
        </Tabs.Tab>
      </Tabs>
    </Gapped>
  );
};

export const Warning = () => {
  const [active, setActive] = useState("fuji");

  return (
    <Gapped>
      <Tabs value={active} onValueChange={setActive}>
        <Tabs.Tab
          data-tid="TabId"
          id="fuji"
          data-active={active == "fuji"}
          warning
        >
          Fuji
        </Tabs.Tab>
      </Tabs>
    </Gapped>
  );
};
