const Pagination = ({ count, itemsPerPage }) => {
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
      <li className="page-item" key={`${index}numbrer`}>
        <a className="page-link" href="#">
          {index + 1}
        </a>
      </li>
    ));
  };
  return (
    <nav aria-label="Page navigation example">
      <ul className="pagination justify-content-center">
        <li className="page-item disabled">
          <a className="page-link">Previous</a>
        </li>
        {generatePageNumbers()}
        <li className="page-item">
          <a className="page-link" href="#">
            Next
          </a>
        </li>
      </ul>
    </nav>
  );
};

export default Pagination;
