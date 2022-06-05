import List from "./list";
import Pagination from "./pagination";
import { getItems } from "../../services/paginationService";
import { useEffect, useState } from "react";
import FilterForm from "./filterForm";

const ListView = ({ endpoint, columnNames, filters }) => {
  const itemsPerPage = 6;
  const [items, setItems] = useState([]);
  const [count, setCount] = useState([]);
  const [filterString, setFilterString] = useState("");
  const [orderBy, setOrderBy] = useState(undefined);

  const getListItems = async (skip) => {
    const orderByVar = orderBy ? orderBy[0] : undefined;
    const orderByDirectionVar = orderBy ? orderBy[1] : undefined;

    const response = await getItems(
      endpoint,
      skip,
      itemsPerPage,
      orderByVar ? orderByVar : "Name",
      orderByDirectionVar ? orderByDirectionVar : 1,
      filterString
    );

    if (response.hasException == false) {
      setItems(response.data.items);
      setCount(response.data.count);
    }
  };

  useEffect(() => {
    getListItems(0, "Name", 1).catch((e) => console.log(e));
  }, [filterString]);

  return (
    <>
      <FilterForm filters={filters} setFilterString={setFilterString} />
      <List
        columnNames={columnNames}
        data={items}
        orderBy={orderBy}
        setOrderBy={setOrderBy}
      />
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
