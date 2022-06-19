import { useEffect, useState } from "react";
import { useParams } from "react-router-dom";
import { getItemById } from "../../services/commonService";

const CategoryDetails = () => {
  let { id } = useParams();
  const [category, setCategory] = useState(null);

  useEffect(() => {
    const getCategory = async () => {
      var item = await getItemById("categories", id);

      setCategory(item);
    };

    getCategory();
  }, []);

  return (
    <>
      <h2 className="formTitle">Детайли за категория</h2>

      <form>
        <div className="mb-3">
          <label htmlFor="exampleInputEmail1" className="form-label">
            Id
          </label>
          <input
            type="email"
            className="form-control custom-input"
            id="exampleInputEmail1"
            disabled={true}
            aria-describedby="emailHelp"
            value={category ? category.id : ""}
          />
          <label htmlFor="exampleInputEmail1" className="form-label">
            Име
          </label>
          <input
            type="email"
            className="form-control custom-input"
            id="exampleInputEmail1"
            disabled={true}
            aria-describedby="emailHelp"
            value={category ? category.name : ""}
          />
        </div>
      </form>
    </>
  );
};

export default CategoryDetails;
