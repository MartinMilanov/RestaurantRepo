import List from "./list";
import Pagination from "./pagination";
import { getItems } from "../../services/paginationService";
import { useEffect, useState } from "react";
import FilterForm from "./filterForm";

const ListView = ({ endpoint, columnNames, filters }) => {
  const [items, setItems] = useState([]);
  const [count, setCount] = useState([]);
  const [filterString, setFilterString] = useState();

  useEffect(() => {
    const execute = async () => {
      const response = await getItems(endpoint, 0, 6, "Name", 1, filterString);

      if (response.hasException == false) {
        setItems(response.data.items);
        setCount(response.data.count);
      }
    };

    execute();
  }, []);

  return (
    <>
      <FilterForm filters={filters} />
      <List columnNames={columnNames} data={items} />
      {/* <div style={{ display: "flex" }}>
        <Pagination />
      </div> */}
    </>
  );
};

export default ListView;
