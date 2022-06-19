import { useState } from "react";
import { getItemById, updateItem } from "../../services/commonService";
import { useNavigate, useParams } from "react-router-dom";
import { useEffect } from "react";
import { getItems } from "../../services/paginationService";

const FoodUpdate = () => {
  let { id } = useParams();
  const navigate = useNavigate();

  const [values, setValues] = useState({ name: "", price: 0, categoryId: "" });
  const [categories, setCategories] = useState([]);

  useEffect(() => {
    const setup = async () => {
      var food = await getItemById("foods", id);
      const categoriesQuery = await getItems("categories", 0, 100, "Name", 1);

      var newState = values;
      newState.name = food.name;
      newState.price = food.price;
      newState.categoryId = food.categoryId;

      setValues({ ...newState });

      setCategories(categoriesQuery.data.items);
    };

    setup();
  }, []);

  const onSubmit = async (event) => {
    event.preventDefault();
    await updateItem("foods", id, values);
    navigate(-1);
  };

  const onChange = (name, value) => {
    var newState = values;

    newState[name] = value;

    setValues({ ...newState });
  };

  return (
    <>
      <h2 className="formTitle">Обновяване на храна</h2>

      <form
        onSubmit={(event) => {
          onSubmit(event);
        }}
      >
        <div className="mb-3">
          <label className="form-label">Име</label>
          <input
            required={true}
            type="text"
            className="form-control custom-input"
            value={values.name}
            onChange={(e) => onChange("name", e.target.value)}
          />
          <label className="form-label">Цена</label>
          <input
            type="text"
            className="form-control custom-input"
            pattern="^\d*(\.\d{0,2})?$"
            value={values.price}
            onChange={(e) => onChange("price", e.target.value)}
          />
          <div className="form-group">
            <label htmlFor="exampleFormControlSelect1">Категория</label>
            <select
              className="form-control custom-input"
              id="exampleFormControlSelect1"
              onChange={(e) => onChange("categoryId", e.target.value)}
            >
              <option value="">None</option>
              {categories.length > 0
                ? categories.map((cat) => (
                    <option
                      key={cat.id}
                      value={cat.id}
                      selected={cat.id === values.categoryId}
                    >
                      {cat.name}
                    </option>
                  ))
                : null}
            </select>
          </div>
        </div>
        <button className="btn btn-warning">Обнови</button>

        <button
          className="btn btn-cancel"
          type="button"
          onClick={() => {
            navigate(-1);
          }}
        >
          Отказ
        </button>
      </form>
    </>
  );
};

export default FoodUpdate;
