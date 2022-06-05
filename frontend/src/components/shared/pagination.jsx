import { useState } from "react";

const Pagination = ({ count, itemsPerPage }) => {
  const [currentPage, setCurrentPage] = useState(1);

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
      >
        <a className="page-link" href="#">
          {index + 1}
        </a>
      </li>
    ));
  };

  const next = () => {
    var totalPages = Math.ceil(count / itemsPerPage);

    if (totalPages > currentPage) {
      setCurrentPage(currentPage + 1);
      //call a method provided by the parent component for items
    }
  };

  const prev = () => {
    if (currentPage - 1 !== 0) {
      setCurrentPage(currentPage - 1);
      //call a method provided by the parent component for items
    }
  };

  return (
    <nav aria-label="Page navigation example">
      <ul className="pagination justify-content-center">
        <li className={`page-item ${currentPage == 1 ? "disabled" : null}`}>
          <a className="page-link" onClick={() => prev()}>
            Previous
          </a>
        </li>
        {generatePageNumbers()}
        <li
          className={`page-item ${
            currentPage == Math.ceil(count / itemsPerPage) ? "disabled" : null
          }`}
        >
          <a className="page-link" onClick={() => next()}>
            Next
          </a>
        </li>
      </ul>
    </nav>
  );
};

export default Pagination;
