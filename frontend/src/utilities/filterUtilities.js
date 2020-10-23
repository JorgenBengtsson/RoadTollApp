import { monthToNumber } from "./dateUtilities";

const filterItemOnMonth = (item, month) => {
  return parseInt(item.date.substring(5, 7)) === monthToNumber(month);
};

export { filterItemOnMonth };
