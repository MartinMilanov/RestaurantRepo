import { useEffect, useState } from "react";
import { useParams } from "react-router-dom";
import { getItemById, updateItem } from "../../services/commonService";
import { useNavigate } from "react-router-dom";

const CategoryUpdate = () => {
  let { id } = useParams();

  const [category, setCategory] = useState(null);

  const [values, setValues] = useState({ name: "" });

  const navigate = useNavigate();

  const onSubmit = async (event) => {
    event.preventDefault();
    await updateItem("categories", id, values);
    navigate(-1);
  };

  const onChange = (name, value) => {
    var newState = values;

    newState[name] = value;

    setValues({ ...newState });
  };

  useEffect(() => {
    const setup = async () => {
      var item = await getItemById("categories", id);
      var newState = values;

      newState["name"] = item.name;

      setValues({ ...newState });
      setCategory(item);
    };

    setup();
  }, []);

  return (
    <>
      <h3 className="formTitle">Обновяване на категория</h3>
      <form
        onSubmit={(event) => {
          onSubmit(event);
        }}
      >
        <div className="mb-3">
          <label htmlFor="exampleInputEmail1" className="form-label">
            Име
          </label>
          <input
            required={true}
            type="text"
            className="form-control custom-input"
            id="exampleInputEmail1"
            aria-describedby="emailHelp"
            value={values.name}
            onChange={(e) => onChange("name", e.target.value)}
          />
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

export default CategoryUpdate;
