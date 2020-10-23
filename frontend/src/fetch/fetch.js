const baseURL = "https://localhost:44365/api";

const getAllToll = () =>
  fetch(baseURL + "/tolls/").then((response) => response.json());

const getAllTollPassByMonth = (month) =>
  fetch(baseURL + "/tolls/GetAllByMonth/" + month).then((response) =>
    response.json()
  );

const getAllTollPassByMonthAndCar = (month, regnr) =>
  fetch(
    baseURL + "/tolls/GetAllByMonthCar/" + month + "/" + regnr
  ).then((response) => response.json());

const getTollById = (id) =>
  fetch(baseURL + "/tolls/" + id).then((response) => response.json());

const updateToll = (id, toll) => {
  const payload = {
    method: "PUT",
    headers: {
      "Content-type": "application/json; charset=UTF-8",
    },
    body: JSON.stringify(toll),
  };
  return fetch(baseURL + "/tolls/" + id, payload).then((response) => {
    if (response.ok) {
      return response.json();
    } else {
      if (response.status == "404") {
        throw "Id not recoginzed";
      } else {
        throw "FEL";
      }
    }
  });
};

export {
  getAllToll,
  getAllTollPassByMonth,
  getAllTollPassByMonthAndCar,
  getTollById,
  updateToll,
};
