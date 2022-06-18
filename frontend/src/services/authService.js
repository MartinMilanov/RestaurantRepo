import axios from "axios";
import { apiUrl } from "../settings/settings";

export const tryLogIn = async (username, password) => {
  try {
    var result = await axios.post(`${apiUrl}authenticate/login`, {
      username: username,
      password: password,
    });

    if (result.data.token !== undefined) {
      localStorage.setItem("token", result.data.token);
      localStorage.setItem("username", result.data.username);
      return true;
    } else {
      return false;
    }
  } catch (e) {
    return false;
  }
};

export const logOut = () => {
  if (isLoggedIn()) {
    localStorage.removeItem("token");
    localStorage.removeItem("username");
  }
};

export const getUsername = () => {
  var username = localStorage.getItem("username");

  if (username) {
    return username;
  }

  return null;
};

export const getToken = () => {
  var auth = localStorage.getItem("token");

  if (auth) {
    return auth;
  }

  return null;
};

export const isLoggedIn = () => {
  if (getToken() === null) {
    return false;
  } else {
    return true;
  }
};
