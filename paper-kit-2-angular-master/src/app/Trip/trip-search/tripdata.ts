export const tripdata = () => {
  const trips = [
    {
      id: 1,
      place: "Mountains",
      location: "Malamjaba",
      date: "02/15/2024",
      price: 1500,
      weather: "Sunny",
      saftystatus: "Safe",
    },
    {
      id: 2,
      place: "Ushutop",
      location: "Kalam",
      date: "05/15/2024",
      price: 2000,
      weather: "Snow",
      safetystatus: "Closed",
    },
  ];

  if (!localStorage.getItem("trips")) {
    localStorage.setItem("trips", JSON.stringify(trips));
    console.log("Trips data added to localStorage.");
  }
};

export const gettrips = () => {
  return JSON.parse(localStorage.getItem("trips") || "[]");
};
