import React, { useState } from "react";
import { Gapped, Paging } from "@skbkontur/react-ui";
import { Meta } from "@storybook/react";

export default {
  title: "Paging",
} as Meta;

export const Default = () => {
  const [activePage, setActivePage] = useState(2);

  return (
    <Gapped>
      <Paging
        data-tid="PagingId"
        data-active={activePage}
        data-pagesCount={8}
        onPageChange={(activePage) => setActivePage(activePage)}
        activePage={activePage}
        pagesCount={8}
      />
    </Gapped>
  );
};

export const Disabled = () => {
  const [activePage, setActivePage] = useState(1);

  return (
    <Gapped>
      <Paging
        data-tid="PagingId"
        disabled
        data-active={activePage}
        data-pagesCount={8}
        onPageChange={(activePage) => setActivePage(activePage)}
        activePage={activePage}
        pagesCount={8}
      />
    </Gapped>
  );
};

export const DataPagesCountIsNotSet = () => {
  const [activePage, setActivePage] = useState(1);

  return (
    <Gapped>
      <Paging
        data-tid="PagingId"
        data-active={activePage}
        onPageChange={(activePage) => setActivePage(activePage)}
        activePage={activePage}
        pagesCount={8}
      />
    </Gapped>
  );
};

export const DataActiveIsNotSet = () => {
  const [activePage, setActivePage] = useState(1);

  return (
    <Gapped>
      <Paging
        data-tid="PagingId"
        data-pagesCount={8}
        onPageChange={(activePage) => setActivePage(activePage)}
        activePage={activePage}
        pagesCount={8}
      />
    </Gapped>
  );
};

export const OnLastPage = () => {
  const [activePage, setActivePage] = useState(8);

  return (
    <Gapped>
      <Paging
        data-tid="PagingId"
        data-active={activePage}
        onPageChange={(activePage) => setActivePage(activePage)}
        activePage={activePage}
        pagesCount={8}
        data-pagesCount={8}
      />
    </Gapped>
  );
};
