const List = () => {
  return (
    <table class="table">
      <thead class="thead-light">
        <tr>
          <th scope="col">#</th>
          <th scope="col" className={"onHoverTh"}>
            First
          </th>
          <th scope="col" className={"onHoverTh"}>
            Last
          </th>
          <th scope="col" className={"onHoverTh"}>
            Handle
          </th>
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
  );
};

export default List;
