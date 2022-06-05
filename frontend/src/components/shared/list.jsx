import Pagination from "./pagination";

const List = ({ columnNames, data }) => {
  const generateTableHeaders = () => {
    return (
      <>
        {columnNames.map((x, index) => (
          <th scope="col" className={"onHoverTh"} key={`${index}th`}>
            {x.charAt(0).toUpperCase() + x.slice(1)}
          </th>
        ))}
      </>
    );
  };

  const generateTableRows = () => {
    const dataValues = data.map((x) => Object.entries(x).map((c) => c[1]));
    return (
      <>
        {dataValues.map((x, index) => (
          <tr key={`${index}trKey`}>
            <th scope="row" key={`${index}thtr`}>
              {index}
            </th>
            {x.slice(1).map((d, index) => (
              <td key={`${index}td`}>
                {d.toString() == "false"
                  ? "No"
                  : d.toString() == "true"
                  ? "Yes"
                  : d}
              </td>
            ))}
            <td>
              <button className="btn btn-primary listBtn">
                <i className="bi bi-eye"></i>
              </button>

              <button className="btn btn-warning listBtn">
                <i className="bi bi-pencil-square"></i>
              </button>

              <button className="btn btn-danger listBtn">
                <i className="bi bi-trash"></i>
              </button>
            </td>
          </tr>
        ))}
      </>
    );
  };

  return (
    <>
      <table className="table">
        <thead className="thead-light">
          <tr>
            <th scope="col">#</th>
            {generateTableHeaders()}
            <th scope="col"></th>
          </tr>
        </thead>
        <tbody>{generateTableRows()}</tbody>
      </table>
    </>
  );
};

export default List;
