/* eslint-disable @typescript-eslint/no-explicit-any */
import React, { useEffect, useState } from "react";
import { Gapped, Link, Select, Tooltip } from "@skbkontur/react-ui";
import type { Meta } from "@storybook/react";

export enum SelectTestIds {
  SelectId = "SelectId",
}

export default {
  title: "Select",
} as Meta;

export const DefaultButton = () => {
  const [value, setValue] = useState();
  const items = ["One", "Two", "Three", Select.SEP, "Four"];

  return (
    <Gapped>
      <Select
        data-attribute-without-value={""}
        data-tid={SelectTestIds.SelectId}
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

    return (
      <Link data-attribute-without-value={""} {...linkProps}>
        {params.label}
      </Link>
    );
  };

  return (
    <Gapped>
      <Select
        data-tid={SelectTestIds.SelectId}
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
        data-tid={SelectTestIds.SelectId}
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
        data-tid={SelectTestIds.SelectId}
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
        data-tid={SelectTestIds.SelectId}
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
        data-tid={SelectTestIds.SelectId}
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
        data-tid={SelectTestIds.SelectId}
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
        data-tid={SelectTestIds.SelectId}
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
        data-tid={SelectTestIds.SelectId}
        items={items}
        value={value}
        onValueChange={setValue}
        _renderButton={renderLinkButton}
      />
    </Gapped>
  );
};

export const Hidden = () => {
  const [value, setValue] = useState();
  const items = ["One", "Two", "Three", Select.SEP, "Four"];
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
        <Select
          data-tid={SelectTestIds.SelectId}
          items={items}
          value={value}
          onValueChange={setValue}
        />
      )}
    </Gapped>
  );
};

export const WithTooltip = () => {
  const [value, setValue] = useState();
  const items = ["One", "Two", "Three", Select.SEP, "Four"];

  return (
    <Gapped>
      <Tooltip render={() => <div>TooltipText</div>} closeButton>
        <Select
          data-tid={SelectTestIds.SelectId}
          items={items}
          value={value}
          onValueChange={setValue}
        />
      </Tooltip>
    </Gapped>
  );
};
