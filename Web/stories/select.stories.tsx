import React, { useState } from "react";
import { Select, Gapped, Button, Link } from "@skbkontur/react-ui";
import { Meta } from "@storybook/react";

export default {
  title: "Select",
} as Meta;

export const DefaultButton = () => {
  const [value, setValue] = useState();
  const items = ["One", "Two", "Three", Select.SEP, "Four"];

  return (
    <Gapped>
      <Select
        data-tid="SelectId"
        items={items}
        value={value}
        onValueChange={setValue}
      />
    </Gapped>
  );
};

export const DefaultLink = () => {
  const [value, setValue] = useState();
  const items = ["One", "Two", "Three", Select.SEP, "Four"];

  const renderLinkButton = (params: any) => {
    const linkProps = {
      disabled: params.disabled,
      _button: true,
      _buttonOpened: params.opened,

      onClick: params.onClick,
      onKeyDown: params.onKeyDown,
    };

    return <Link {...linkProps}>{params.label}</Link>;
  };

  return (
    <Gapped>
      <Select
        data-tid="SelectId"
        items={items}
        value={value}
        onValueChange={setValue}
        _renderButton={renderLinkButton}
      />
    </Gapped>
  );
};

export const Error = () => {
  const [value, setValue] = useState();
  const items = ["One", "Two", "Three", Select.SEP, "Four"];

  return (
    <Gapped>
      <Select
        data-tid="SelectId"
        items={items}
        value={value}
        onValueChange={setValue}
        error
      />
    </Gapped>
  );
};

export const Warning = () => {
  const [value, setValue] = useState();
  const items = ["One", "Two", "Three", Select.SEP, "Four"];

  return (
    <Gapped>
      <Select
        data-tid="SelectId"
        items={items}
        value={value}
        onValueChange={setValue}
        warning
      />
    </Gapped>
  );
};

export const DisabledButton = () => {
  const [value, setValue] = useState();
  const items = ["One", "Two", "Three", Select.SEP, "Four"];

  return (
    <Gapped>
      <Select
        data-tid="SelectId"
        items={items}
        value={value}
        onValueChange={setValue}
        disabled
      />
    </Gapped>
  );
};

export const DisabledLink = () => {
  const [value, setValue] = useState();
  const items = ["One", "Two", "Three", Select.SEP, "Four"];

  const renderLinkButton = (params: any) => {
    const linkProps = {
      disabled: true,
      _button: true,
      _buttonOpened: params.opened,

      onClick: params.onClick,
      onKeyDown: params.onKeyDown,
    };

    return <Link {...linkProps}>{params.label}</Link>;
  };

  return (
    <Gapped>
      <Select
        data-tid="SelectId"
        items={items}
        value={value}
        onValueChange={setValue}
        _renderButton={renderLinkButton}
      />
    </Gapped>
  );
};

export const Search = () => {
  const [value, setValue] = useState();
  const items = ["One", "Two", "Three", Select.SEP, "Four"];

  return (
    <Gapped>
      <Select
        data-tid="SelectId"
        items={items}
        value={value}
        onValueChange={setValue}
        search
      />
    </Gapped>
  );
};

export const FilledButton = () => {
  const [value, setValue] = useState("Two");
  const items = ["One", "Two", "Three", Select.SEP, "Four"];

  return (
    <Gapped>
      <Select
        data-tid="SelectId"
        items={items}
        value={value}
        onValueChange={setValue}
      />
    </Gapped>
  );
};

export const FilledLink = () => {
  const [value, setValue] = useState("Two");
  const items = ["One", "Two", "Three", Select.SEP, "Four"];

  const renderLinkButton = (params: any) => {
    const linkProps = {
      disabled: params.disabled,
      _button: true,
      _buttonOpened: params.opened,

      onClick: params.onClick,
      onKeyDown: params.onKeyDown,
    };

    return <Link {...linkProps}>{params.label}</Link>;
  };

  return (
    <Gapped>
      <Select
        data-tid="SelectId"
        items={items}
        value={value}
        onValueChange={setValue}
        _renderButton={renderLinkButton}
      />
    </Gapped>
  );
};
