import type { Meta } from "@storybook/react";
import { Gapped, Tooltip } from "@skbkontur/react-ui";
import React, { useEffect, useState } from "react";

export enum LabelTestIds {
  LabelId = "LabelId",
}

export default {
  title: "Label",
} as Meta;

export const Default = () => (
  <Gapped>
    <div data-attribute-without-value={""} data-tid={LabelTestIds.LabelId}>
      TODO
    </div>
  </Gapped>
);

export const Hidden = () => {
  const [isVisible, setIsVisible] = useState(true);
  useEffect(() => {
    const timer = setTimeout(() => {
      setIsVisible(false);
    }, 2000);

    return () => clearTimeout(timer);
  }, []);

  return (
    <Gapped>
      {isVisible && <div data-tid={LabelTestIds.LabelId}>TODO</div>}
    </Gapped>
  );
};

export const WithTooltip = () => (
  <Gapped>
    <Tooltip render={() => <div>TooltipText</div>}>
      <div data-tid={LabelTestIds.LabelId}>TODO</div>
    </Tooltip>
  </Gapped>
);
