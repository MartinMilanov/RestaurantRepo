import axios from "axios";
import { apiUrl } from "../settings/settings";

export const deleteItem = async (endpoint, id) => {
  var apiUrlConstruct = `${apiUrl}${endpoint}/${id}`;

  var result = await axios.delete(apiUrlConstruct);
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

  var result = await axios.post(apiUrlConstruct, body);

  if (result.data.HasException !== true) {
    window.alert(result.data.data);
  } else {
    window.alert(result.data.ExceptionMessage);
  }
};
