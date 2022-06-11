import { useEffect, useState } from "react";
import { useParams } from "react-router-dom";
import { getItemById } from "../../services/commonService";

const FoodDetails = () => {
  let { id } = useParams();
  const [food, setFood] = useState(null);
  const [category, setCategory] = useState(null);

  useEffect(() => {
    const getFood = async () => {
      var food = await getItemById("foods", id);
      var category = await getItemById("categories", food.categoryId);

      setCategory(category);
      setFood(food);
    };

    getFood();
  }, []);

  return (
    <>
      <h2 className="formTitle">Details</h2>

      <form>
        <div className="mb-3">
          <label className="form-label">Id</label>
          <input
            type="text"
            className="form-control custom-input"
            disabled={true}
            value={food ? food.id : ""}
          />
          <label className="form-label">Name</label>
          <input
            type="text"
            className="form-control custom-input"
            disabled={true}
            value={food ? food.name : ""}
          />
          <label className="form-label">Price</label>
          <input
            type="number"
            className="form-control custom-input"
            disabled={true}
            value={food ? food.price : ""}
          />
          <label className="form-label">Category</label>
          <input
            type="text"
            className="form-control custom-input"
            disabled={true}
            value={category ? category.name : "None"}
          />
        </div>
      </form>
    </>
  );
};

export default FoodDetails;
