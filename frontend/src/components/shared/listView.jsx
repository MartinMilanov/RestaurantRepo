import List from "./list";
import Pagination from "./pagination";
import { getItems } from "../../services/paginationService";
import { useEffect, useState } from "react";
import FilterForm from "./filterForm";
import { Link } from "react-router-dom";
import { toast } from "react-toastify";
import { useRef } from "react";

const ListView = ({ endpoint, columnNames, filters }) => {
  const itemsPerPage = 6;
  const [items, setItems] = useState([]);
  const [count, setCount] = useState([]);
  const [filterString, setFilterString] = useState("");
  const [orderBy, setOrderBy] = useState(undefined);

  const downloadElement = useRef(null);
  const [downloadUrl, setDownloadUrl] = useState("");

  const getListItems = async (skip) => {
    const orderByVar = orderBy ? orderBy[0] : "Name";
    const orderByDirectionVar = orderBy ? orderBy[1] : 1;

    const response = await getItems(
      endpoint,
      skip,
      itemsPerPage,
      orderByVar,
      orderByDirectionVar,
      filterString
    );

    if (response.hasException === false) {
      setItems(response.data.items);
      setCount(response.data.count);
    }
  };

  const downloadFile = async () => {
    const orderByVar = orderBy ? orderBy[0] : "Name";
    const orderByDirectionVar = orderBy ? orderBy[1] : 1;

    const response = await getItems(
      endpoint,
      0,
      100000,
      orderByVar,
      orderByDirectionVar,
      filterString
    );

    if (response.hasException === false) {
      var json = JSON.stringify(response.data.items, null, 4);

      const blob = new Blob([json]);
      const fileDownloadUrl = URL.createObjectURL(blob);

      toast.success("Successfully downloaded file");
      setDownloadUrl(fileDownloadUrl);
      this.dofileDownload.click();
    } else {
      return undefined;
    }
  };

  useEffect(() => {
    getListItems(0, "Name", 1).catch((e) => console.log(e));
  }, [filterString, orderBy]);

  useEffect(() => {
    if (downloadUrl !== "" && downloadUrl !== undefined) {
      downloadElement.current.click();
      URL.revokeObjectURL(downloadUrl);
      setDownloadUrl("");
    }
  }, [downloadUrl]);

  return (
    <>
      <FilterForm filters={filters} setFilterString={setFilterString} />

      <div className="create-wrapper">
        <Link to={`/${endpoint}/create`} className="btn btn-success btn-right">
          Създай
        </Link>
        <button
          className="btn btn-warning btn-right export-button"
          onClick={() => downloadFile()}
        >
          Експортирай всички
        </button>

        <a
          className="hidden"
          download={`${endpoint}.json`}
          href={downloadUrl}
          ref={downloadElement}
        >
          download it
        </a>
      </div>

      <List
        columnNames={columnNames}
        data={items}
        orderBy={orderBy}
        setOrderBy={setOrderBy}
        endpoint={endpoint}
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
