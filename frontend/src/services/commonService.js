import axios from "axios";
import { apiUrl } from "../settings/settings";
import { getToken } from "./authService";
import { toast } from "react-toastify";

export const deleteItem = async (endpoint, id) => {
  try {
    const jwt = getToken();

    const config = {
      headers: {
        Authorization: `Bearer ${jwt}`,
      },
    };

    var apiUrlConstruct = `${apiUrl}${endpoint}/${id}`;

    await axios.delete(apiUrlConstruct, config);
  } catch (e) {
    toast.error(e.message);
  }
};

export const getItemById = async (endpoint, id) => {
  try {
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
  } catch (e) {
    return null;
  }
};

export const createItem = async (endpoint, body) => {
  try {
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
      toast.success(result.data.data);
    } else {
      toast.error(result.data.ExceptionMessage);
    }
  } catch (e) {
    toast.error(e.message);
  }
};

export const updateItem = async (endpoint, id, body) => {
  try {
    const jwt = getToken();

    const config = {
      headers: {
        Authorization: `Bearer ${jwt}`,
      },
    };

    var apiUrlConstruct = `${apiUrl}${endpoint}/${id}`;

    var result = await axios.put(apiUrlConstruct, body, config);

    if (result.data.HasException !== true) {
      toast.success(result.data.data);
    } else {
      toast.error(result.data.ExceptionMessage);
    }
  } catch (e) {
    toast.error(e.message);
  }
};
