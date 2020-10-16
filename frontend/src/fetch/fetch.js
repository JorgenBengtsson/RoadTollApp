const baseURL = "https://localhost:44365/api";

const getAllTollPassByMonth = (month) =>
  fetch(baseURL + "/tolls/GetAllByMonth/" + month).then((response) =>
    response.json()
  );

const getAllTollPassByMonthAndCar = (month, regnr) =>
  fetch(
    baseURL + "/tolls/GetAllByMonthCar/" + month + "/" + regnr
  ).then((response) => response.json());

export { getAllTollPassByMonth, getAllTollPassByMonthAndCar };
