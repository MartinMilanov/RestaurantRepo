import axios from "axios";
import { apiUrl } from "../settings/settings";
import { getToken } from "./authService";

export const deleteItem = async (endpoint, id) => {
  const jwt = getToken();

  const config = {
    headers: {
      Authorization: `Bearer ${jwt}`,
    },
  };

  var apiUrlConstruct = `${apiUrl}${endpoint}/${id}`;

  await axios.delete(apiUrlConstruct, config);
};

export const getItemById = async (endpoint, id) => {
  const jwt = getToken();

  const config = {
    headers: {
      Authorization: `Bearer ${jwt}`,
    },
  };

  var apiUrlConstruct = `${apiUrl}${endpoint}/${id}`;

  var result = await axios.get(apiUrlConstruct, config);

  if (result.data.HasException !== true) {
    return result.data.data;
  } else {
    return null;
  }
};

export const createItem = async (endpoint, body) => {
  const jwt = getToken();

  const config = {
    headers: {
      Authorization: `Bearer ${jwt}`,
    },
  };

  var apiUrlConstruct = `${apiUrl}${endpoint}/create`;

  var result = await axios
    .post(apiUrlConstruct, body, config)
    .catch((x) => console.log(x));

  if (result.data.HasException !== true) {
    window.alert(result.data.data);
  } else {
    window.alert(result.data.ExceptionMessage);
  }
};

export const updateItem = async (endpoint, id, body) => {
  const jwt = getToken();

  const config = {
    headers: {
      Authorization: `Bearer ${jwt}`,
    },
  };

  var apiUrlConstruct = `${apiUrl}${endpoint}/${id}`;

  var result = await axios.put(apiUrlConstruct, body, config);

  if (result.data.HasException !== true) {
    window.alert(result.data.data);
  } else {
    window.alert(result.data.ExceptionMessage);
  }
};
