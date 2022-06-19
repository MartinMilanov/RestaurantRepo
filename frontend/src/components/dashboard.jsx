import { Link } from "react-router-dom";

const Dashboard = () => {
  return (
    <>
      <div className="row">
        <div className="col-sm-3 dashboard-card">
          <div className="card">
            <div className="card-body">
              <h5 className="card-title">Храни</h5>
              <p className="card-text">Кликнете тук за менежиране на храните</p>
              <Link to={"/foods"} className="btn btn-primary">
                Храни
              </Link>
            </div>
          </div>
        </div>
        <div className="col-sm-3 dashboard-card">
          <div className="card">
            <div className="card-body">
              <h5 className="card-title">Категории</h5>
              <p className="card-text">
                Кликнете тук за менежиране на категориите
              </p>
              <Link to={"/categories"} className="btn btn-primary">
                Категории
              </Link>
            </div>
          </div>
        </div>
        <div className="col-sm-3 dashboard-card">
          <div className="card">
            <div className="card-body">
              <h5 className="card-title">Сметки</h5>
              <p className="card-text">
                Кликнете тук за менежиране на сметките
              </p>
              <Link to={"/bills"} className="btn btn-primary">
                Сметки
              </Link>
            </div>
          </div>
        </div>
        <div className="col-sm-3 dashboard-card">
          <div className="card">
            <div className="card-body">
              <h5 className="card-title">Резервации</h5>
              <p className="card-text">
                Кликнете тук за менежиране на резервациите
              </p>
              <Link to={"/reservations"} className="btn btn-primary">
                Резервации
              </Link>
            </div>
          </div>
        </div>
        <div className="col-sm-3 dashboard-card">
          <div className="card">
            <div className="card-body">
              <h5 className="card-title">Маси</h5>
              <p className="card-text">Кликнете тук за менежиране на масите</p>
              <Link to={"/tables"} className="btn btn-primary">
                Маси
              </Link>
            </div>
          </div>
        </div>
      </div>
    </>
  );
};

export default Dashboard;
