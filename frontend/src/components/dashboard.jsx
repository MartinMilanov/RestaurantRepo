const Dashboard = () => {
  return (
    <>
      <div className="row">
        <div className="col-sm-3 dashboard-card">
          <div className="card">
            <div className="card-body">
              <h5 className="card-title">Foods</h5>
              <p className="card-text">
                This is where you can create read update and delete your foods
              </p>
              <a className="btn btn-primary">Go somewhere</a>
            </div>
          </div>
        </div>
        <div className="col-sm-3 dashboard-card">
          <div className="card">
            <div className="card-body">
              <h5 className="card-title">Categories</h5>
              <p className="card-text">
                This is where you can create read update and delete your
                categories
              </p>
              <a className="btn btn-primary">Go somewhere</a>
            </div>
          </div>
        </div>
        <div className="col-sm-3 dashboard-card">
          <div className="card">
            <div className="card-body">
              <h5 className="card-title">Bills</h5>
              <p className="card-text">
                This is where you can create read update and delete your bills
              </p>
              <a className="btn btn-primary">Go somewhere</a>
            </div>
          </div>
        </div>
        <div className="col-sm-3 dashboard-card">
          <div className="card">
            <div className="card-body">
              <h5 className="card-title">Reservations</h5>
              <p className="card-text">
                This is where you can create read update and delete your
                reservations
              </p>
              <a className="btn btn-primary">Go somewhere</a>
            </div>
          </div>
        </div>
        <div className="col-sm-3 dashboard-card">
          <div className="card">
            <div className="card-body">
              <h5 className="card-title">Tables</h5>
              <p className="card-text">
                This is where you can create read update and delete your tables
              </p>
              <a className="btn btn-primary">Go somewhere</a>
            </div>
          </div>
        </div>
      </div>
    </>
  );
};

export default Dashboard;
