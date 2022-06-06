import axios from "axios";
import { apiUrl } from "../settings/settings";

export const deleteItem = async (endpoint, id) => {
  var apiUrlConstruct = `${apiUrl}${endpoint}/${id}`;

  await axios.delete(apiUrlConstruct);
};
