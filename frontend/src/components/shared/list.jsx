import { deleteItem } from "../../services/commonService";
import { Link } from "react-router-dom";
import { translate } from "../../services/translationService";

const List = ({ columnNames, data, orderBy, setOrderBy, endpoint }) => {
  const generateTableHeaders = () => {
    return (
      <>
        {columnNames.map((x, index) => (
          <th
            scope="col"
            className={"onHoverTh"}
            key={`${index}th`}
            onClick={() =>
              onClickChangeOrderBy(x.charAt(0).toUpperCase() + x.slice(1))
            }
          >
            {translate(x.charAt(0).toUpperCase() + x.slice(1))}
            {isHeaderInOrderBy(x.charAt(0).toUpperCase() + x.slice(1)) ? (
              orderBy[1] == 1 ? (
                <i className="bi bi-caret-up-fill"></i>
              ) : (
                <i className="bi bi-caret-down-fill"></i>
              )
            ) : null}
          </th>
        ))}
      </>
    );
  };

  const isHeaderInOrderBy = (colName) => {
    colName = colName.split(" ").join("");
    if (orderBy !== undefined) {
      if (orderBy.indexOf(colName) !== -1) {
        return true;
      } else {
        return false;
      }
    } else {
      return false;
    }
  };

  const generateTableRows = () => {
    const dataValues = data.map((x) => Object.entries(x).map((c) => c[1]));
    return (
      <>
        {dataValues.map((x, index) => (
          <tr key={`${index}trKey`}>
            <th scope="row" key={`${index}thtr`}>
              {index + (getCurrentPageWithDom() - 1) * 6 + 1}
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
              <Link
                to={`/${endpoint}/details/${x[0]}`}
                className="btn btn-primary listBtn"
              >
                <i className="bi bi-eye"></i>
              </Link>

              <Link
                to={`/${endpoint}/update/${x[0]}`}
                className="btn btn-warning listBtn"
              >
                <i className="bi bi-pencil-square"></i>
              </Link>

              <button
                className="btn btn-danger listBtn"
                onClick={() => onClickDeleteItem(x[0])}
              >
                <i className="bi bi-trash"></i>
              </button>
            </td>
          </tr>
        ))}
      </>
    );
  };

  const onClickChangeOrderBy = (colName) => {
    colName = colName.split(" ").join("");
    if (orderBy !== undefined) {
      var exists = orderBy.indexOf(colName);
      var newState;
      if (exists == -1) {
        newState = [colName, 1];
      } else {
        newState = orderBy;
        if (newState[1] == 1) {
          newState[1] = 2;
        } else {
          newState[1] = 1;
        }
      }
      setOrderBy([...newState]);
    } else {
      var newState = [colName, 1];
      setOrderBy([...newState]);
    }
  };

  const getCurrentPageWithDom = () => {
    var pageNumber = parseInt(
      document.getElementsByClassName("page-item active")[0].innerText
    );

    return pageNumber;
  };

  const onClickDeleteItem = async (id) => {
    var proceed = window.confirm("Are you sure you want to delete this item ?");
    window.location.reload();
    if (proceed) {
      await deleteItem(endpoint, id).catch((e) => console.log(e));
    }
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
