/* eslint-disable react/prop-types */

const MoviesItem = ({ movies }) => {
  return (
    <li
      //style={{
      //background: "red",
      //}}
      className="p-4 font-black"
    >
      {movies}
    </li>
  );
};

export default MoviesItem;
