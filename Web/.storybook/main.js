/** @type { import('@storybook/react-vite').StorybookConfig } */
const config = {
  stories: ["../stories/**/*.stories.@(ts|tsx)"],
  addons: ["@storybook/addon-actions"],
  framework: {
    name: "@storybook/react-vite",
    options: {},
  },
  typescript: { check: false, reactDocgen: false },
};
export default config;
