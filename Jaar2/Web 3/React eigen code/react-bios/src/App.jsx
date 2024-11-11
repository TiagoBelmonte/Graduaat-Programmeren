// Enkel naam komt vanuit een dependency of third party package

import CourseItem from "./components/CourseItem";
import Courses from "./components/Courses";
import "./App.css";
import Button from "./components/Button.jsx";
import Counter from "./components/Counter.jsx";

const subTitle = "Vak over React en Node.js";
const { fName, lName } = {
  fName: "Tiago",
  lName: "Belmonte",
};

const courses = ["Web 1", "Web 2", "Web 3", "Mobile"];

function App() {
  const handleClick = () => {
    alert("Dit is een alert");
  };
  return (
    <>
      <h1 className="title">Web 3</h1>
      <h3>{subTitle}</h3>
      <p>{`Voornaam: ${fName}, Achternaam: ${lName}`}</p>

      <Button onClick={handleClick}> APP BTN </Button>

      <Courses courses={courses} />

      <p>
        Lorem ipsum dolor sit amet consectetur adipisicing elit. Expedita
        blanditiis eum natus a quam, corporis magni delectus autem rem
        consectetur ad suscipit. Cum mollitia quas ut enim molestias, dicta
        eligendi.
      </p>
      <p>
        Lorem ipsum dolor sit amet consectetur adipisicing elit. Expedita
        blanditiis eum natus a quam, corporis magni delectus autem rem
        consectetur ad suscipit. Cum mollitia quas ut enim molestias, dicta
        eligendi.
      </p>
      <p>
        Lorem ipsum dolor sit amet consectetur adipisicing elit. Expedita
        blanditiis eum natus a quam, corporis magni delectus autem rem
        consectetur ad suscipit. Cum mollitia quas ut enim molestias, dicta
        eligendi.
      </p>

      <br></br>
      <br></br>
      <Counter></Counter>
    </>
  );
}

export default App;
