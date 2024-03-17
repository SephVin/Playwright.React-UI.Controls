import React from "react";
import { Gapped, Input, Tooltip } from "@skbkontur/react-ui";
import { Meta } from "@storybook/react";

export default {
  title: "Tooltip",
} as Meta;

export const Default = () => {
  const render = () => (
    <div
      style={{
        width: 250,
        fontSize: "large",
        fontFamily: "Segoe UI",
      }}
    >
      TODO
    </div>
  );

  return (
    <Gapped>
      <Tooltip
        data-tid="TooltipId"
        render={render}
        pos="right top"
        useWrapper
        closeButton
      >
        <Input data-tid="InputId" />
      </Tooltip>
    </Gapped>
  );
};

export const WithSingleLink = () => {
  const render = () => (
    <div
      style={{
        width: 250,
        fontSize: "large",
        fontFamily: "Segoe UI",
      }}
    >
      TODO <a href="https://kontur.ru">ссылка</a>
    </div>
  );

  return (
    <Gapped>
      <Tooltip data-tid="TooltipId" render={render} pos="right top" useWrapper>
        <Input data-tid="InputId" />
      </Tooltip>
    </Gapped>
  );
};

export const WithLinks = () => {
  const render = () => (
    <div
      style={{
        width: 250,
        fontSize: "large",
        fontFamily: "Segoe UI",
      }}
    >
      TODO 1 <a href="https://kontur.ru">ссылка 1</a>, TODO 2
      <a href="https://school.kontur.ru">ссылка 2</a>
    </div>
  );

  return (
    <Gapped>
      <Tooltip data-tid="TooltipId" render={render} pos="right top" useWrapper>
        <Input data-tid="InputId" />
      </Tooltip>
    </Gapped>
  );
};
