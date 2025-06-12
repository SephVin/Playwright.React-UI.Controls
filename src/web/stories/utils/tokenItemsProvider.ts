import { delay } from '@skbkontur/react-ui/lib/utils';

export const tokens = ['First', 'Second', 'Third', 'Fourth', 'Fifth', 'Sixth'];

export const getItems = async (query: string) => {
  const items = tokens.filter(x => x.toLowerCase().includes(query.toLowerCase()) || x.toString() === query);
  await delay(300);

  return items;
};
