const months = [
  "January",
  "February",
  "March",
  "April",
  "May",
  "June",
  "July",
  "August",
  "September",
  "October",
  "November",
  "December",
];

const monthToNumber = (month) => {
  return months.indexOf(month) + 1;
};

export { months, monthToNumber };
