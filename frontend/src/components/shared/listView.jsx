import List from "./list";
import Pagination from "./pagination";
import { getItems } from "../../services/paginationService";
import { useEffect, useState } from "react";
import FilterForm from "./filterForm";

const ListView = ({ endpoint, columnNames, filters }) => {
  const itemsPerPage = 6;
  const [items, setItems] = useState([]);
  const [count, setCount] = useState([]);
  const [filterString, setFilterString] = useState();

  const getListItems = async (skip, orderBy, orderByDirection) => {
    const response = await getItems(
      endpoint,
      skip,
      itemsPerPage,
      orderBy,
      orderByDirection,
      filterString
    );

    if (response.hasException == false) {
      setItems(response.data.items);
      setCount(response.data.count);
    }
  };

  useEffect(() => {
    getListItems(0, "Name", 1);
  }, []);

  return (
    <>
      <FilterForm filters={filters} />
      <List columnNames={columnNames} data={items} />
      <div style={{ display: "flex" }}>
        <Pagination
          count={count}
          itemsPerPage={itemsPerPage}
          getItems={getListItems}
        />
      </div>
    </>
  );
};

export default ListView;
