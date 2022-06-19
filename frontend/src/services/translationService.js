const kvp = [
  { key: "Name", value: "Име" },
  { key: "Price", value: "Цена" },
  { key: "Table Number", value: "Номер на маса" },
  { key: "Seats", value: "Места" },
  { key: "Reservee Name", value: "Име на резервиралия" },
  { key: "People Count", value: "Брой души" },
  { key: "Date", value: "Дата" },
  { key: "CreatedBy", value: "Създаден от" },
  { key: "Created By", value: "Създаден от" },
  { key: "Total", value: "Общо" },
  { key: "Closed", value: "Затворено на" },
  { key: "Is Closed", value: "Затворено" },
];

export const translate = (key) => {
  var value = kvp.filter((x) => x.key === key)[0].value;

  return value;
};
