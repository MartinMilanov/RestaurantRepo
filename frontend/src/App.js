import "./AdminPanel.css";
import "../node_modules/bootstrap-icons/font/bootstrap-icons.scss";
import Header from "./components/header";
import Container from "./components/container";
import { BrowserRouter } from "react-router-dom";
import { GlobalContext } from "./GlobalContext";
import { useEffect, useState } from "react";
import { getUsername, isLoggedIn } from "./services/authService";
function App() {
  const [username, setUsername] = useState("");
  const [loggedIn, setLoggedIn] = useState(false);

  useEffect(() => {
    var isLoggedInResult = isLoggedIn();

    var result = getUsername();

    if (result) {
      setLoggedIn(isLoggedInResult);
      setUsername(result);
    }
  }, []);
  return (
    <>
      <GlobalContext.Provider
        value={{ username, setUsername, loggedIn, setLoggedIn }}
      >
        <BrowserRouter>
          <Header />
          <Container />
        </BrowserRouter>
      </GlobalContext.Provider>
    </>
  );
}

export default App;
