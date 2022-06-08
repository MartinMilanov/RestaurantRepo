import axios from "axios";
import { apiUrl } from "../settings/settings";

export const deleteItem = async (endpoint, id) => {
  var apiUrlConstruct = `${apiUrl}${endpoint}/${id}`;

  await axios.delete(apiUrlConstruct);
};

export const getItemById = async (endpoint, id) => {
  var apiUrlConstruct = `${apiUrl}${endpoint}/${id}`;

  var result = await axios.get(apiUrlConstruct);

  if (result.data.hasException !== true) {
    return result.data.data;
  } else {
    return null;
  }
};
