const Header = () => {
  return (
    <header className="navbar navbar-dark sticky-top  flex-md-nowrap p-0 shadow">
      <span className="navbar-brand col-md-3 col-lg-2 me-0 px-3 fs-6">
        Company name
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
          <span className="nav-link px-3">Sign out</span>
        </div>
      </div>
    </header>
  );
};

export default Header;
