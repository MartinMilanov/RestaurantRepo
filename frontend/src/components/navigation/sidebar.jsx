import { Link } from "react-router-dom";

const Sidebar = () => {
  return (
    <nav
      id="sidebarMenu"
      className="col-md-3 col-lg-2 col-xl-2 d-md-block bg-light sidebar collapse"
    >
      <div className="position-sticky pt-3">
        <ul className="nav flex-column">
          <li className="nav-item">
            <Link
              to={`/`}
              key={"homeLink"}
              className="nav-link active"
              aria-current="page"
            >
              <svg
                xmlns="http://www.w3.org/2000/svg"
                width={24}
                height={24}
                viewBox="0 0 24 24"
                fill="none"
                stroke="currentColor"
                strokeWidth={2}
                strokeLinecap="round"
                strokeLinejoin="round"
                className="feather feather-home align-text-bottom"
                aria-hidden="true"
              >
                <path d="M3 9l9-7 9 7v11a2 2 0 0 1-2 2H5a2 2 0 0 1-2-2z" />
                <polyline points="9 22 9 12 15 12 15 22" />
              </svg>
              Начало
            </Link>
          </li>
          <li className="nav-item">
            <Link to={`categories`} key={"categoriesLink"} className="nav-link">
              <svg
                xmlns="http://www.w3.org/2000/svg"
                width={24}
                height={24}
                viewBox="0 0 24 24"
                fill="none"
                stroke="currentColor"
                strokeWidth={2}
                strokeLinecap="round"
                strokeLinejoin="round"
                className="feather feather-file align-text-bottom"
                aria-hidden="true"
              >
                <path d="M13 2H6a2 2 0 0 0-2 2v16a2 2 0 0 0 2 2h12a2 2 0 0 0 2-2V9z" />
                <polyline points="13 2 13 9 20 9" />
              </svg>
              Категории
            </Link>
          </li>
          <li className="nav-item">
            <Link to={`foods`} key={"foodLink"} className="nav-link">
              <svg
                xmlns="http://www.w3.org/2000/svg"
                width={24}
                height={24}
                viewBox="0 0 24 24"
                fill="none"
                stroke="currentColor"
                strokeWidth={2}
                strokeLinecap="round"
                strokeLinejoin="round"
                className="feather feather-shopping-cart align-text-bottom"
                aria-hidden="true"
              >
                <circle cx={9} cy={21} r={1} />
                <circle cx={20} cy={21} r={1} />
                <path d="M1 1h4l2.68 13.39a2 2 0 0 0 2 1.61h9.72a2 2 0 0 0 2-1.61L23 6H6" />
              </svg>
              Храни
            </Link>
          </li>
          <li className="nav-item">
            <Link to={`tables`} key={"tableLink"} className="nav-link">
              <svg
                xmlns="http://www.w3.org/2000/svg"
                width={24}
                height={24}
                viewBox="0 0 24 24"
                fill="none"
                stroke="currentColor"
                strokeWidth={2}
                strokeLinecap="round"
                strokeLinejoin="round"
                className="feather feather-users align-text-bottom"
                aria-hidden="true"
              >
                <path d="M17 21v-2a4 4 0 0 0-4-4H5a4 4 0 0 0-4 4v2" />
                <circle cx={9} cy={7} r={4} />
                <path d="M23 21v-2a4 4 0 0 0-3-3.87" />
                <path d="M16 3.13a4 4 0 0 1 0 7.75" />
              </svg>
              Маси
            </Link>
          </li>
          <li className="nav-item">
            <Link to={`reservations`} key={"resrervLink"} className="nav-link">
              <i
                className="bi bi-journal-bookmark"
                style={{ marginRight: 4 }}
              ></i>
              Резервации
            </Link>
          </li>
          <li className="nav-item">
            <Link to={`bills`} key={"billsLink"} className="nav-link">
              <i className="bi bi-cash" style={{ marginRight: 4 }}></i>
              Сметки
            </Link>
          </li>
        </ul>
      </div>
    </nav>
  );
};
export default Sidebar;
