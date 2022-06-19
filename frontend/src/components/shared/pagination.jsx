import { useState } from "react";

const Pagination = ({ count, itemsPerPage, getItems }) => {
  const [currentPage, setCurrentPage] = useState(1);

  const next = () => {
    var totalPages = Math.ceil(count / itemsPerPage);

    if (totalPages > currentPage) {
      setCurrentPage(currentPage + 1);
      getItems(itemsPerPage * currentPage, "Name", 1);
    }
  };

  const prev = () => {
    if (currentPage - 1 >= 0) {
      setCurrentPage(currentPage - 1);
      getItems(itemsPerPage * (currentPage - 2), "Name", 1);
    }
  };

  const getItemsByPageNumber = (number) => {
    if (number >= 1 && number <= Math.ceil(count / itemsPerPage)) {
      setCurrentPage(number);
      getItems(itemsPerPage * (number - 1), "Name", 1);
    }
  };

  const generatePageNumbers = () => {
    var numberOfPages = [];

    if (count < itemsPerPage || count == itemsPerPage) {
      numberOfPages[0] = 1;
    } else {
      numberOfPages = Array.from(
        { length: Math.ceil(count / itemsPerPage) },
        () => Math.floor(Math.random())
      );
    }

    return numberOfPages.map((x, index) => (
      <li
        className={`page-item ${currentPage == index + 1 ? "active" : null}`}
        key={`${index}numbrer`}
        onClick={() => getItemsByPageNumber(index + 1)}
      >
        <a className="page-link" href="#">
          {index + 1}
        </a>
      </li>
    ));
  };

  return (
    <nav aria-label="Page navigation example">
      <ul className="pagination justify-content-center">
        <li className={`page-item ${currentPage == 1 ? "disabled" : null}`}>
          <a className="page-link" onClick={() => prev()}>
            Назад
          </a>
        </li>
        {generatePageNumbers()}
        <li
          className={`page-item ${
            currentPage == Math.ceil(count / itemsPerPage) ? "disabled" : null
          }`}
        >
          <a className="page-link" onClick={() => next()}>
            Напред
          </a>
        </li>
      </ul>
    </nav>
  );
};

export default Pagination;
