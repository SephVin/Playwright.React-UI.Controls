import React from "react";
import "../react-selenium-testing";
import "../react-selenium-testing-custom-props";

/** @type { import('@storybook/react').Preview } */
const preview = {
  parameters: {},
  decorators: [
    (Story, context) => {
      return (
        <div id="Controls" style={{ padding: 10 }}>
          <Story />
        </div>
      );
    },
  ],
};

export default preview;
