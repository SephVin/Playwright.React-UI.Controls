import { ComboBoxItem } from "@skbkontur/react-ui";
import { delay } from "@skbkontur/react-ui/lib/utils";

export const numbers: ComboBoxItem[] = [
  { label: "First", value: "1" },
  { label: "Second", value: "2" },
  { label: "Third", value: "3" },
  { label: "Fourth", value: "4" },
  { label: "Fifth", value: "5" },
  { label: "Sixth", value: "6" },
];

const findSimilarItem =
  (query: string) =>
  (item: ComboBoxItem): boolean => {
    const queryRegExp = new RegExp(query, "ig");
    return queryRegExp.test(item.label) || queryRegExp.test(item.value);
  };

const getItemsByQuery =
  (items: ComboBoxItem[], withDelay: boolean) =>
  async (query: string): Promise<ComboBoxItem[]> => {
    if (withDelay) {
      await delay(300);
    }
    return items.filter(findSimilarItem(query));
  };

export const getNumbers = getItemsByQuery(numbers, false);
export const getNumbersWithDelay = getItemsByQuery(numbers, true);
