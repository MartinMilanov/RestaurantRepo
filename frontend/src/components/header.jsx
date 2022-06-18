import { useContext } from "react";
import { Link } from "react-router-dom";
import { GlobalContext } from "../GlobalContext";
import { isLoggedIn, logOut } from "../services/authService";

const Header = () => {
  const { username, setUsername } = useContext(GlobalContext);

  const logOutHandler = () => {
    logOut();
    setUsername("");
  };
  return (
    <header className="navbar navbar-dark sticky-top  flex-md-nowrap p-0 shadow">
      <span className="navbar-brand col-md-3 col-lg-2 me-0 px-3 fs-6">
        Restaurant Manager
      </span>
      <button
        className="navbar-toggler position-absolute d-md-none collapsed"
        type="button"
        data-bs-toggle="collapse"
        data-bs-target="#sidebarMenu"
        aria-controls="sidebarMenu"
        aria-expanded="false"
        aria-label="Toggle navigation"
      >
        <span className="navbar-toggler-icon"></span>
      </button>
      <div className="navbar-nav">
        <div className="nav-item text-nowrap">
          {isLoggedIn() ? (
            <div className="login-links-container">
              <span className="nav-link px-3 userLink">{username}</span>
              <span
                className="nav-link px-3 userLink"
                onClick={() => logOutHandler()}
              >
                Logout
              </span>
            </div>
          ) : (
            <Link to={"/login"} className="nav-link px-3 userLink">
              Log in
            </Link>
          )}
        </div>
      </div>
    </header>
  );
};

export default Header;
