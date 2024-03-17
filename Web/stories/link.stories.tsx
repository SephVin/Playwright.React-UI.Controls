import React from "react";
import { Link, Gapped } from "@skbkontur/react-ui";
import { Meta } from "@storybook/react";

export default {
  title: "Link",
} as Meta;

export const Default = () => (
  <Gapped>
    <Link data-tid="LinkId" href="https://google.com/">
      TODO
    </Link>
  </Gapped>
);

export const Disabled = () => (
  <Gapped>
    <Link data-tid="LinkId" href="https://google.com/" disabled>
      TODO
    </Link>
  </Gapped>
);
