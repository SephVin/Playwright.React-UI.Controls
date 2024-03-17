import React, { useState } from "react";
import { Radio, Gapped } from "@skbkontur/react-ui";
import { Meta } from "@storybook/react";

export default {
  title: "Radio",
} as Meta;

export const Default = () => {
  const [chosen, setChosen] = useState("");

  return (
    <Gapped>
      <Radio
        data-tid="RadioId"
        checked={chosen === "checked"}
        value="1"
        onValueChange={(_) => setChosen("checked")}
      >
        TODO
      </Radio>
    </Gapped>
  );
};

export const Disabled = () => {
  return (
    <Gapped>
      <Radio data-tid="RadioId" value="1" disabled>
        TODO
      </Radio>
    </Gapped>
  );
};

export const Error = () => {
  return (
    <Gapped>
      <Radio data-tid="RadioId" value="1" error>
        TODO
      </Radio>
    </Gapped>
  );
};

export const Warning = () => {
  return (
    <Gapped>
      <Radio data-tid="RadioId" value="1" warning>
        TODO
      </Radio>
    </Gapped>
  );
};

export const Checked = () => {
  return (
    <Gapped>
      <Radio data-tid="RadioId" value="1" checked>
        TODO
      </Radio>
    </Gapped>
  );
};
