import axios from "axios";
import { apiUrl } from "../settings/settings";

export const getItems = async (
  endpoint,
  skip,
  take,
  orderBy,
  orderWay,
  filtersString,
  jwtToken
) => {
  const config = {
    headers: {
      Authorization: jwtToken,
    },
  };

  var apiUrlConstruct =
    apiUrl +
    `${endpoint}?Skip=${skip}&Take=${take}&OrderBy=${orderBy}&OrderWay=${orderWay}`;

  if (filtersString) {
    apiUrl += `&${filtersString}`;
  }

  var result = await axios.get(apiUrlConstruct, config);

  return result.data;
};
