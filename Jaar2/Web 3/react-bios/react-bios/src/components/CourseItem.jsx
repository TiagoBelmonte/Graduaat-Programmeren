/* eslint-disable react/prop-types */

const CourseItem = ({ course }) => {
  return (
    <li
      //style={{
      //background: "red",
      //}}
      className="p-4 font-black"
    >
      {course}
    </li>
  );
};

export default CourseItem;
