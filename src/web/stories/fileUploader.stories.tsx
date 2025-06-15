import type { Meta, StoryObj } from "@storybook/react";
import { FileUploader, Gapped, Tooltip } from "@skbkontur/react-ui";
import React, { useEffect, useState } from "react";

export enum FileUploaderTestIds {
  FileUploaderId = "FileUploaderId",
}

const meta: Meta<typeof FileUploader> = {
  title: "FileUploader",
  component: FileUploader,
};
export default meta;

type Story = StoryObj<typeof meta>;

export const Default: Story = {
  render(args) {
    return (
      <Gapped>
        <FileUploader
          data-attribute-without-value={""}
          data-tid={FileUploaderTestIds.FileUploaderId}
          {...args}
        />
      </Gapped>
    );
  },
};

export const Disabled: Story = {
  ...Default,
  args: {
    disabled: true,
  },
};

export const Error: Story = {
  ...Default,
  args: {
    error: true,
  },
};

export const Warning: Story = {
  ...Default,
  args: {
    warning: true,
  },
};

export const Multiple: Story = {
  ...Default,
  args: {
    multiple: true,
  },
};

export const Hidden: Story = {
  render: () => {
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
          <FileUploader data-tid={FileUploaderTestIds.FileUploaderId} />
        )}
      </Gapped>
    );
  },
};

export const WithTooltip: Story = {
  render: () => (
    <Gapped>
      <Tooltip render={() => <div>TooltipText</div>}>
        <FileUploader data-tid={FileUploaderTestIds.FileUploaderId} />
      </Tooltip>
    </Gapped>
  ),
};
