import React, { useState } from "react";
import { Button, Gapped } from "@skbkontur/react-ui";
import { Meta } from "@storybook/react";

export default {
  title: "Button",
} as Meta;

export const Default = () => {
  const [isShowLabel, setShowLabel] = useState(false);

  return (
    <Gapped>
      <Button data-tid="ButtonId" onClick={() => setShowLabel(!isShowLabel)}>
        TODO
      </Button>
      {isShowLabel && <div data-tid="LabelId">Hello world!</div>}
    </Gapped>
  );
};

export const Disabled = () => (
  <Gapped>
    <Button data-tid="ButtonId" disabled>
      TODO
    </Button>
  </Gapped>
);

export const Error = () => (
  <Gapped>
    <Button data-tid="ButtonId" error>
      TODO
    </Button>
  </Gapped>
);

export const Warning = () => (
  <Gapped>
    <Button data-tid="ButtonId" warning>
      TODO
    </Button>
  </Gapped>
);

export const loading = () => (
  <Gapped>
    <Button data-tid="ButtonId" loading>
      TODO
    </Button>
  </Gapped>
);
