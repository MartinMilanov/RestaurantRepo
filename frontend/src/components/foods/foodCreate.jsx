import { useState } from "react";
import { createItem } from "../../services/commonService";
import { useNavigate } from "react-router-dom";
import { useEffect } from "react";
import { getItems } from "../../services/paginationService";

const FoodCreate = () => {
  const [values, setValues] = useState({ name: "" });
  const [categories, setCategories] = useState([]);

  useEffect(() => {
    const getCategories = async () => {
      const categoriesQuery = await getItems("categories", 0, 100, "Name", 1);

      setCategories(categoriesQuery.data.items);
    };

    getCategories();
  }, []);

  const navigate = useNavigate();

  const onSubmit = async (event) => {
    event.preventDefault();
    await createItem("foods", values);
    navigate(-1);
  };

  const onChange = (name, value) => {
    var newState = values;

    newState[name] = value;

    setValues({ ...newState });
  };

  return (
    <>
      <h2 className="formTitle">Create food entry</h2>

      <form
        onSubmit={(event) => {
          onSubmit(event);
        }}
      >
        <div className="mb-3">
          <label className="form-label">Name</label>
          <input
            required={true}
            type="text"
            className="form-control custom-input"
            onChange={(e) => onChange("name", e.target.value)}
          />
          <label className="form-label">Price</label>
          <input
            type="text"
            className="form-control custom-input"
            pattern="^\d*(\.\d{0,2})?$"
            onChange={(e) => onChange("price", e.target.value)}
          />
          <div className="form-group">
            <label htmlFor="exampleFormControlSelect1">Category</label>
            <select
              className="form-control custom-input"
              id="exampleFormControlSelect1"
              onChange={(e) => onChange("categoryId", e.target.value)}
            >
              <option value="">None</option>
              {categories.length > 0
                ? categories.map((cat) => (
                    <option key={cat.id} value={cat.id}>
                      {cat.name}
                    </option>
                  ))
                : null}
            </select>
          </div>
        </div>
        <button className="btn btn-success">Create</button>
        <button
          className="btn btn-cancel"
          type="button"
          onClick={() => {
            navigate(-1);
          }}
        >
          Cancel
        </button>
      </form>
    </>
  );
};

export default FoodCreate;
