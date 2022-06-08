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
      <h2 className="formTitle">Details</h2>

      <form>
        <div className="mb-3">
          <label for="exampleInputEmail1" className="form-label">
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
          <label for="exampleInputEmail1" className="form-label">
            Name
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
