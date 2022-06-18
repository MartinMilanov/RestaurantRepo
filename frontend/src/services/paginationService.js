import axios from "axios";
import { apiUrl } from "../settings/settings";
import { getToken } from "./authService";
import { toast } from "react-toastify";

export const getItems = async (
  endpoint,
  skip,
  take,
  orderBy,
  orderWay,
  filtersString,
  jwtToken
) => {
  try {
    const jwt = getToken();

    const config = {
      headers: {
        Authorization: `Bearer ${jwt}`,
      },
    };

    var apiUrlConstruct =
      apiUrl +
      `${endpoint}?Skip=${skip}&Take=${take}&OrderBy=${orderBy}&OrderWay=${orderWay}`;

    if (filtersString) {
      apiUrlConstruct += `&${filtersString}`;
    }

    var result = await axios.get(apiUrlConstruct, config);

    return result.data;
  } catch (e) {
    toast.error(e.message);
    return { data: { items: [] } };
  }
};
