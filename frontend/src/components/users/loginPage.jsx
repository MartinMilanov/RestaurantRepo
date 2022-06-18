import { useState } from "react";
import { isLoggedIn, tryLogIn } from "../../services/authService";
import { useNavigate } from "react-router-dom";
import { useEffect } from "react";
import { useContext } from "react";
import { GlobalContext } from "../../GlobalContext";

const Login = () => {
  const [values, setValues] = useState({ username: "", password: "" });

  const { setUsername } = useContext(GlobalContext);

  const navigate = useNavigate();

  const onSubmit = async (event) => {
    event.preventDefault();
    var result = await tryLogIn(values.username, values.password);

    if (result === false) {
      window.alert("Unsuccessful login");
    } else {
      window.alert("Successful login");
      setUsername(localStorage.getItem("username"));
      navigate(-1);
    }
  };

  const onChange = (name, value) => {
    var newState = values;

    newState[name] = value;

    setValues({ ...newState });
  };

  useEffect(() => {
    if (isLoggedIn()) {
      navigate(-1);
    }
  }, []);

  return (
    <>
      <h2 className="log-in-title">Log in</h2>
      <form
        onSubmit={(event) => {
          onSubmit(event);
        }}
      >
        <div className="mb-3">
          <label for="exampleInputEmail1" className="form-label">
            Email address
          </label>
          <input
            className="form-control"
            id="exampleInputEmail1"
            required={true}
            aria-describedby="emailHelp"
            onChange={(e) => onChange("username", e.target.value)}
          />
          <div id="emailHelp" className="form-text">
            We'll never share your email with anyone else.
          </div>
        </div>
        <div className="mb-3">
          <label for="exampleInputPassword1" className="form-label">
            Password
          </label>
          <input
            type="password"
            className="form-control"
            id="exampleInputPassword1"
            required={true}
            onChange={(e) => onChange("password", e.target.value)}
          />
        </div>
        <button type="submit" className="btn btn-primary">
          Login
        </button>
      </form>
    </>
  );
};

export default Login;
