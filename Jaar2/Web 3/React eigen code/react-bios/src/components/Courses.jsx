/* eslint-disable react/prop-types */

import CourseItem from "./CourseItem";
//css module -> importeer je eigenlijk JS object
import styles from "./Courses.module.css";
import Button from "./Button.jsx";

const Courses = ({ courses }) => {
  const handleClick = () => {
    console.log("geklikt op de knop");
  };

  return (
    <>
      <h3 className={styles.title}>Vakken</h3>
      <ul>
        {courses.map((c) => (
          <CourseItem key={c} course={c} />
        ))}
      </ul>
      {/* <button
        className="px-4 py-2 bg-teal-500 hover:bg-teal-300 rounded-lg text-white"
        onClick={handleClick}
      >
        Klik mij
      </button> */}

      {courses.length ? <p>Er zijn vakken</p> : <p>Er zijn geen vakken</p>}

      <Button onClick={handleClick}>
        <div>
          <p>Dit is een paragraaf</p>
        </div>
      </Button>
    </>
  );
};

export default Courses;
