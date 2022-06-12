import axios from "axios";
import { apiUrl } from "../settings/settings";

export const deleteItem = async (endpoint, id) => {
  var apiUrlConstruct = `${apiUrl}${endpoint}/${id}`;

  await axios.delete(apiUrlConstruct);
};

export const getItemById = async (endpoint, id) => {
  var apiUrlConstruct = `${apiUrl}${endpoint}/${id}`;

  var result = await axios.get(apiUrlConstruct);

  if (result.data.HasException !== true) {
    return result.data.data;
  } else {
    return null;
  }
};

export const createItem = async (endpoint, body) => {
  var apiUrlConstruct = `${apiUrl}${endpoint}/create`;

  var result = await axios
    .post(apiUrlConstruct, body)
    .catch((x) => console.log(x));

  if (result.data.HasException !== true) {
    window.alert(result.data.data);
  } else {
    window.alert(result.data.ExceptionMessage);
  }
};

export const updateItem = async (endpoint, id, body) => {
  var apiUrlConstruct = `${apiUrl}${endpoint}/${id}`;

  var result = await axios.put(apiUrlConstruct, body);

  if (result.data.HasException !== true) {
    window.alert(result.data.data);
  } else {
    window.alert(result.data.ExceptionMessage);
  }
};
