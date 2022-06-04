import Pagination from "./pagination";

const List = () => {
  const object = { name: "hello", age: "22", hasABowl: "nobro" };

  const fillTableHeaders = () => {
    return (
      <>
        {Object.keys(object).map((x, index) => (
          <th scope="col" className={"onHoverTh"} key={index}>
            {x.charAt(0).toUpperCase() + x.slice(1)}
          </th>
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
            {fillTableHeaders()}
            <th scope="col"></th>
          </tr>
        </thead>
        <tbody>
          <tr>
            <th scope="row">1</th>
            <td>Mark</td>
            <td>Otto</td>
            <td>@mdo</td>
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
          <tr>
            <th scope="row">1</th>
            <td>Mark</td>
            <td>Otto</td>
            <td>@mdo</td>
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
          <tr>
            <th scope="row">1</th>
            <td>Mark</td>
            <td>Otto</td>
            <td>@mdo</td>
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
        </tbody>
      </table>
      <div style={{ display: "flex" }}>
        <Pagination />
      </div>
    </>
  );
};

export default List;
