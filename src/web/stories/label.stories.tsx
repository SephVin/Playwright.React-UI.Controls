import React from "react";
import {Gapped} from "@skbkontur/react-ui";
import { Meta } from "@storybook/react";

export default {
    title: "Label",
} as Meta;

export const Default = () => (
    <Gapped>
        <div data-tid="LabelId">TO DO</div>
    </Gapped>
);