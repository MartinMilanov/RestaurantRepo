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
          <tr>
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
              <button class="btn btn-primary listBtn">
                <i class="bi bi-eye"></i>
              </button>

              <button class="btn btn-warning listBtn">
                <i class="bi bi-pencil-square"></i>
              </button>

              <button class="btn btn-danger listBtn">
                <i class="bi bi-trash"></i>
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
        <thead class="thead-light">
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
